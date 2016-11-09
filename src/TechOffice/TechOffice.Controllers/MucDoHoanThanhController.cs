using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using Ninject;
using PagedList;
using System.Threading.Tasks;
using System.Net;
using AnThinhPhat.Entities.Results;

namespace AnThinhPhat.WebUI.Controllers
{
    public class MucDoHoanThanhController : OfficeController
    {
        [Inject]
        public IMucDoHoanThanhRepository MucDoRepository { get; set; }

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
            var items = MucDoRepository.GetAll().Select(x => x.ToDataViewModel()).ToList();

            var pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, TechOfficeConfig.PAGESIZE));
        }

        [HttpPost]
        public async Task<JsonResult> Create(BaseDataViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var ht = model.ToDataResult<MucDoHoanThanhResult>().Update((u) =>
                {
                    u.CreatedBy = UserName;
                });

                return await ExecuteResultAsync(async () =>
                {
                    return await MucDoRepository.AddAsync(ht);
                });
            });
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            var data = MucDoRepository.Single(id).ToDataViewModel();

            return PartialView("_PartialPageBaseDataEdit", data);
        }

        public async Task<JsonResult> Edit(int id, BaseDataViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var ht = model.ToDataResult<MucDoHoanThanhResult>().Update((u) =>
                 {
                     u.Id = id;
                     u.LastUpdatedBy = UserName;
                 });

                return await ExecuteResultAsync(async () =>
                {
                    return await MucDoRepository.UpdateAsync(ht);
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
                    return await MucDoRepository.DeleteByAsync(id);
                });
            });
        }
    };
}