using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.Menu;
using Ninject;
using PagedList;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;
using System.IO;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = (RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN))]
    public class PageReferenceController : OfficeController
    {
        [Inject]
        public IPageReferenceRepository PageReferenceRepository { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Lists the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult List(int? page)
        {
            var pages = PageReferenceRepository.GetAll().Select(x => x.ToDataViewModel());
            var pageNumber = page ?? 1;

            return PartialView(pages.ToPagedList(pageNumber, TechOfficeConfig.PAGESIZE));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new PageReferenceViewModel());
        }

        [HttpPost]
        public ActionResult Add(PageReferenceViewModel model)
        {
            var fileName = string.Format("{0}{1}", Guid.NewGuid().ToString("N"), Path.GetExtension(model.Image.FileName));
            var dataSave = model.ToDataResult().Update(x =>
            {
                x.CreatedBy = UserName;
                x.UrlImage = fileName;
            });

            var result = PageReferenceRepository.Add(dataSave);
            if (result == Services.SaveResult.SUCCESS)
                SaveFiles(dataSave.Id, fileName, model.Image);

            return RedirectToRoute(UrlLink.PAGE_REFERENCE);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = PageReferenceRepository.Single(id).ToDataViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, PageReferenceViewModel model)
        {
            var cv = model.ToDataResult().Update(x =>
            {
                x.LastUpdatedBy = UserName;
            });

            if (PageReferenceRepository.Update(cv) == Services.SaveResult.SUCCESS)
            {
                if (model.Image != null)
                    SaveFiles(model.Id, model.UrlImage, model.Image);
            }

            return RedirectToRoute(UrlLink.PAGE_REFERENCE);
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

                return await ExecuteResultAsync(async () => await PageReferenceRepository.DeleteByAsync(id));
            });
        }

        private string EnsureFolderPhoto(int id)
        {
            try
            {
                //1. Get folder upload
                var folderUpload = Server.MapPath(TechOfficeConfig.FOLDER_UPLOAD_PAGEREFERENCE);
                EnsureFolder(folderUpload);

                var folderPhoto = Path.Combine(folderUpload, id.ToString().PadLeft(TechOfficeConfig.LENGTHFOLDER, TechOfficeConfig.PAD_CHAR));
                EnsureFolder(folderPhoto);

                return folderPhoto;
            }
            catch (Exception ex)
            {
                LogService.Error("Has error in while create new Temp folder upload", ex);
                throw;
            }
        }

        private void SaveFiles(int id, string newFileName, HttpPostedFileBase file)
        {
            ExecuteTryLogException(() =>
            {
                var folderPhoto = EnsureFolderPhoto(id);
                if (file.FileName != null)
                {
                    var savedFileName = Path.Combine(folderPhoto, newFileName);
                    try
                    {
                        file.SaveAs(savedFileName); // Save the file
                    }
                    catch (Exception ex)
                    {
                        LogService.Error($"Has error in while save file {file.FileName}", ex);
                    }
                }
            });
        }
    }
}