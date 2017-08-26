using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using Ninject;
using PagedList;
using AnThinhPhat.ViewModel.ThuTuc;
using System.Collections.Generic;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN)]
    public class LinhVucThuTucController : OfficeController
    {
        [Inject]
        public ILinhVucThuTucRepository ThuTucRepository { get; set; }

        private IEnumerable<LinhVucThuTucResult> _listLinhVucThuTuc;

//<<<<<<< HEAD
        public ActionResult Index()
        {
            GetAndUpdateName();
            //=======
            //        //public ActionResult Index()
            //        //{
            //        //    _listLinhVucThuTuc = ThuTucRepository.GetAll();
            //        //    _listLinhVucThuTuc.OrderByDescending(x => x.Id).ToList().ForEach(x =>
            //        //      {
            //        //          x.Ten = GetNameMultiple(x);
            //        //      });
            //>>>>>>> 26082017

            var model = new LinhVucThuTucViewModel { LinhVucThuTuces = _listLinhVucThuTuc };

            return View(model);
        }

        /// <summary>
        ///     Lists the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult List(int? page)
        {
            var items = ThuTucRepository.GetAll().Select(x => x.ToDataViewModel()).ToList();

            var pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, TechOfficeConfig.PAGESIZE));
        }

//<<<<<<< HEAD
        [HttpPost]
        public async Task<JsonResult> Create(LinhVucThuTucViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var result = model.ToDataResult<LinhVucThuTucResult>().Update(u =>
                {
                    u.ParentId = model.ParentId ?? 0;
                    u.CreatedBy = UserName;
                });

                return await ExecuteResultAsync(async () => await ThuTucRepository.AddAsync(result));
            });
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            GetAndUpdateName();

            var data = ThuTucRepository.Single(id).ToDataViewModel().
                Update(x => x.LinhVucThuTuces = _listLinhVucThuTuc);

            return PartialView("_PartialPageEdit", data);
        }
//=======
//        //[HttpPost]
//        //public async Task<JsonResult> Create(LinhVucThuTucViewModel model)
//        //{
//        //    return await ExecuteWithErrorHandling(async () =>
//        //    {
//        //        var result = model.ToDataResult<LinhVucThuTucResult>().Update(u =>
//        //        {
//        //            u.ParentId = model.ParentId ?? 0;
//        //            u.CreatedBy = UserName;
//        //        });

//        //        return await ExecuteResultAsync(async () => await ThuTucRepository.AddAsync(result));
//        //    });
//        //}

//        //[HttpGet]
//        //public PartialViewResult Edit(int id)
//        //{
//        //    _listLinhVucThuTuc = ThuTucRepository.GetAll();
//        //    _listLinhVucThuTuc.ToList().ForEach(x =>
//        //    {
//        //        x.Ten = GetNameMultiple(x);
//        //    });

//        //    var data = ThuTucRepository.Single(id).ToDataViewModel().
//        //        Update(x => x.LinhVucThuTuces = _listLinhVucThuTuc);

//        //    return PartialView("_PartialPageEdit", data);
//        //}
//>>>>>>> 26082017

        public async Task<JsonResult> Edit(int id, LinhVucThuTucViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var cv = model.ToDataResult<LinhVucThuTucResult>().Update(u =>
                {
                    u.Id = id;
                    u.ParentId = model.ParentId ?? 0;
                    u.LastUpdatedBy = UserName;
                });

                return await ExecuteResultAsync(async () => await ThuTucRepository.UpdateAsync(cv));
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

                return await ExecuteResultAsync(async () => await ThuTucRepository.DeleteByAsync(id));
            });
        }

        private string GetNameMultiple(LinhVucThuTucResult thutuc)
        {
            if (thutuc == null)
                return string.Empty;

            var result = thutuc.Ten;

            if (thutuc.ParentId == 0)
                return result;

            var temp = _listLinhVucThuTuc.Where(x => x.Id == thutuc.ParentId).SingleOrDefault();

            result = GetNameMultiple(temp) + " >> " + thutuc.Ten;

            return result;
        }

        private void GetAndUpdateName()
        {
            _listLinhVucThuTuc = ThuTucRepository.GetAll();

            _listLinhVucThuTuc.OrderByDescending(x => x.Id).ToList().ForEach(x =>
            {
                x.Ten = GetNameMultiple(x);
            });
        }
    };
}