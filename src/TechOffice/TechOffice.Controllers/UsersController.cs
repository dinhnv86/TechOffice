using AnThinhPhat.Services.Abstracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AnThinhPhat.ViewModel;
using PagedList;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel.Users;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;

namespace AnThinhPhat.WebUI.Controllers
{
    public class UsersController : OfficeController
    {
        [Inject]
        public IUsersRepository UserRepository { get; set; }

        [Inject]
        public IChucVuRepository ChucVuRepository { get; set; }

        [Inject]
        public IRoleRepository RoleRepository { get; set; }

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
            var items = UserRepository.GetAll().Select(x => x.ToDataViewModel()).ToList();

            var pageNumber = page ?? 1;
            return PartialView(items.ToPagedList(pageNumber, TechOfficeConfig.PAGESIZE));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var cvs = ChucVuRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()).ToList();
            var roles = RoleRepository.GetAll().Select(x => x.ToRoleViewModel()).ToList();
            var userInfo = new AddUserViewModel
            {
                RoleInfos = roles,
                ChucVuInfos = cvs,
            };
            return View(userInfo);
        }

        [HttpPost]
        [ActionName("Create")]
        public JsonResult AddUserInfo(AddUserViewModel model)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var pass = Guid.NewGuid().ToString().Substring(0, 6);
                var result = UserRepository.AddUserWithRoles(model.ToUseResult().Update((x) =>
                  {
                      x.Password = pass;
                      x.CreatedBy = UserName;
                  }));

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = result == Services.SaveResult.SUCCESS ? "SB01" : "SB02"
                };
            });

        }
    }
}
