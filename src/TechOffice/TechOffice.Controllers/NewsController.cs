using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.News;
using Ninject;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.IO;
using System;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN)]
    public class NewsController : OfficeController
    {
        [HttpGet]
        public ActionResult Add()
        {
            var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            var model = new AddNewsViewModel();
            model.NewsCategory = newsCategory;

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddNewsViewModel model, HttpPostedFileBase file)
        {
            var entity = model.ToNewsResult()
            .Update(x =>
            {
                x.CreatedBy = UserName;
                x.UrlImage = file.FileName;
            });


            var result = NewsRepository.Add(entity);
            if (result == Services.SaveResult.SUCCESS)
            {
                SaveFile(entity.Id, file);

                return RedirectToRoute(UrlLink.NEWS_EDIT, new { id = entity.Id });
            }
            else
            {
                ViewBag.HasError = true;
                var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
                model.NewsCategory = newsCategory;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            var news = NewsRepository.Single(id).ToViewModel();

            news.NewsCategory = newsCategory;

            return View(news);
        }

        [HttpPost]
        public ActionResult Edit(AddNewsViewModel model, HttpPostedFileBase file)
        {

            var entity = model.ToNewsResult()
            .Update(x =>
            {
                x.LastUpdatedBy = UserName;
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    x.UrlImage = file.FileName;
                }
            });

            var result = NewsRepository.Update(entity);


            var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            model.NewsCategory = newsCategory;

            if (result == Services.SaveResult.SUCCESS)
            {
                EnsureFolderNews(model.Id);
                SaveFile(model.Id, file);
            }
            else
            {
                ViewBag.HasError = true;
            }
            return View(model);
        }

        private void SaveFile(int newsId, HttpPostedFileBase file)
        {
            if (file == null)
                return;

            var folderNews = EnsureFolderNews(newsId);
            string savedFileName = Path.Combine(folderNews, Path.GetFileName(file.FileName));
            try
            {
                file.SaveAs(savedFileName); // Save the file
            }
            catch (Exception ex)
            {
                LogService.Error(string.Format("Has error in while save file {0}", file.FileName), ex);
            }
        }

        private string EnsureFolderNews(int newsId)
        {
            string folderParentNews = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_NEWS);
            EnsureFolder(folderParentNews);

            string folderNews = Path.Combine(folderParentNews, newsId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PAD_CHAR));
            EnsureFolder(folderNews);

            return folderNews;
        }

        private void EnsureFolder(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        private void DeleteAllFilesInFolderNews(int id)
        {
            string folder = EnsureFolderNews(id);
            if (Directory.Exists(folder))
                Directory.Delete(folder);
        }

        [Inject]
        public INewsRepository NewsRepository { get; set; }

        [Inject]
        public INewsCategoryRepository NewsCategoryRepository { get; set; }
    }
}
