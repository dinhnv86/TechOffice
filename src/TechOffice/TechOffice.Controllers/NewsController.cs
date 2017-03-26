using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnThinhPhat.Services;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.News;
using Ninject;
using System.Threading.Tasks;
using System.Net;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN)]
    public class NewsController : OfficeController
    {
        [Inject]
        public INewsRepository NewsRepository { get; set; }

        [Inject]
        public INewsCategoryRepository NewsCategoryRepository { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            var all = NewsRepository.GetAll();
            return View(all);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            var model = new AddNewsViewModel { NewsCategory = newsCategory };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddNewsViewModel model, HttpPostedFileBase file)
        {
            var entity = model.ToNewsResult()
                .Update(x =>
                {
                    x.CreatedBy = UserName;
                    x.IsDeleted = !model.IsDeleted;
                    x.UrlImage = file.FileName;
                });

            var result = NewsRepository.Add(entity);
            if (result == SaveResult.SUCCESS)
            {
                SaveFile(entity.Id, file);

                return RedirectToRoute(UrlLink.NEWS_EDIT, new { id = entity.Id });
            }
            ViewBag.HasError = true;
            var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            model.NewsCategory = newsCategory;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            var news = NewsRepository.GetById(id).ToViewModel();

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
                    x.IsDeleted = !model.IsDeleted;
                    if (!string.IsNullOrEmpty(file?.FileName))
                    {
                        x.UrlImage = file.FileName;
                    }
                });

            var result = NewsRepository.Update(entity);
            if (result == SaveResult.SUCCESS)
            {
                EnsureFolderNews(model.Id);
                SaveFile(model.Id, file);
            }
            else
            {
                ViewBag.HasError = true;
            }

            var newsCategory = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            model.NewsCategory = newsCategory;

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                if (id == 0)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Bad Request", JsonRequestBehavior.AllowGet);
                }

                return await ExecuteResultAsync(async () => await NewsRepository.DeleteByAsync(id));
            });
        }


        private void SaveFile(int newsId, HttpPostedFileBase file)
        {
            if (string.IsNullOrEmpty(file?.FileName))
                return;

            var folderNews = EnsureFolderNews(newsId);
            var savedFileName = Path.Combine(folderNews, Path.GetFileName(file.FileName));
            try
            {
                file.SaveAs(savedFileName); // Save the file
            }
            catch (Exception ex)
            {
                LogService.Error($"Has error in while save file {file.FileName}", ex);
            }
        }

        private string EnsureFolderNews(int newsId)
        {
            var folderParentNews = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_NEWS);
            EnsureFolder(folderParentNews);

            var folderNews = Path.Combine(folderParentNews,
                newsId.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PAD_CHAR));
            EnsureFolder(folderNews);

            return folderNews;
        }
    }
}