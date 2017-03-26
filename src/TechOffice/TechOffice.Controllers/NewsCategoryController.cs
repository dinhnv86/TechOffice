using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.NewsCategories;
using Ninject;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN)]
    public class NewsCategoryController : OfficeController
    {
        private IEnumerable<NewsCategoryResult> _listNewsCategories;

        [HttpGet]
        public ActionResult Index()
        {
            GetAndUpdateName();

            var model = new NewsCategoryViewModel { NewsCategories = _listNewsCategories };

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
            var items = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel()).ToList();

            var pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, TechOfficeConfig.PAGESIZE));
        }

        [HttpPost]
        public async Task<JsonResult> Create(NewsCategoryViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var result = model.ToDataResult<NewsCategoryResult>().Update(u =>
                {
                    u.CreatedBy = UserName;
                    u.ParentId = model.ParentId ?? 0;
                    u.Position = model.Position ?? 0;
                });

                return await ExecuteResultAsync(async () => await NewsCategoryRepository.AddAsync(result));
            });
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            GetAndUpdateName();

            var data = NewsCategoryRepository.Single(id).ToDataViewModel().
              Update(x => x.NewsCategories = _listNewsCategories);

            return PartialView("_PartialPageEdit", data);
        }

        public async Task<JsonResult> Edit(int id, NewsCategoryViewModel model)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                var cv = model.ToDataResult<NewsCategoryResult>().Update(u =>
                {
                    u.Id = id;
                    u.ParentId = model.ParentId ?? 0;
                    u.Position = model.Position ?? 0;
                    u.LastUpdatedBy = UserName;
                });

                return await ExecuteResultAsync(async () => await NewsCategoryRepository.UpdateAsync(cv));
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

                return await ExecuteResultAsync(async () => await NewsCategoryRepository.DeleteByAsync(id));
            });
        }

        private string GetNameMultiple(NewsCategoryResult news)
        {
            if (news == null)
                return string.Empty;

            var result = news.Ten;

            if (news.ParentId == 0)
                return result;

            var temp = _listNewsCategories.Where(x => x.Id == news.ParentId).SingleOrDefault();

            result = GetNameMultiple(temp) + " >> " + news.Ten;

            return result;
        }

        private void GetAndUpdateName()
        {
            _listNewsCategories = NewsCategoryRepository.GetAll();
            _listNewsCategories.OrderByDescending(x => x.Id).ToList().ForEach(x =>
            {
                x.Ten = GetNameMultiple(x);
            });
        }

        [Inject]
        public INewsCategoryRepository NewsCategoryRepository { get; set; }
    }
}
