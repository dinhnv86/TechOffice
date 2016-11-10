using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using Ninject;
using PagedList;
using System;
using System.Threading.Tasks;
using System.Net;
using AnThinhPhat.Entities.Results;

namespace AnThinhPhat.WebUI.Controllers
{
    public class LinhVucTacNghiepController : OfficeController
    {
        [Inject]
        public ILinhVucTacNghiepRepository LinhVucTacNghiepRepository { get; set; }

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
            var items = LinhVucTacNghiepRepository.GetAll().Select(x => x.ToDataViewModel()).ToList();

            var pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, TechOfficeConfig.PAGESIZE));
        }

        [HttpPost]
        public async Task<JsonResult> Create(BaseDataViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var tn = model.ToDataResult<LinhVucTacNghiepResult>().Update((u) =>
                {
                    u.CreatedBy = UserName;
                });

                return await ExecuteResultAsync(async () =>
                {
                    return await LinhVucTacNghiepRepository.AddAsync(tn);
                });
            });
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            var data = LinhVucTacNghiepRepository.Single(id).ToDataViewModel();

            return PartialView("_PartialPageBaseDataEdit", data);
        }

        public async Task<JsonResult> Edit(int id, BaseDataViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var tn = model.ToDataResult<LinhVucTacNghiepResult>().Update((u) =>
                 {
                     u.Id = id;
                     u.LastUpdatedBy = UserName;
                 });

                return await ExecuteResultAsync(async () =>
                {
                    return await LinhVucTacNghiepRepository.UpdateAsync(tn);
                });
            });
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

                return await ExecuteResultAsync(async () =>
                {
                    return await LinhVucTacNghiepRepository.DeleteByAsync(id);
                });
            });
        }

    };
}