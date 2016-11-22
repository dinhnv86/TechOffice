using AnThinhPhat.Entities;
using AnThinhPhat.Services;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.Users;
using Ninject;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize(Roles = RoleConstant.SUPPER_ADMIN)]
    public class UsersController : OfficeController
    {
        [Inject]
        public IChucVuRepository ChucVuRepository { get; set; }

        [Inject]
        public IRoleRepository RoleRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public IUserRoleRepository UserRoleRepository { get; set; }

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
            var cvs = ChucVuRepository.GetAll().Select(x => x.ToDataInfo()).ToList();
            var roles = RoleRepository.GetAll().Select(x => x.ToRoleViewModel()).ToList();
            var cqs = CoQuanRepository.GetAll().Select(x => x.ToDataInfo()).ToList();

            var userInfo = new AddUserViewModel
            {
                RoleInfos = roles,
                ChucVuInfos = cvs,
                CoQuanInfos = cqs,
            };

            return View(userInfo);
        }

        public ActionResult Edit(int id)
        {
            var user = UserRepository.Single(id);
            var chucvu = ChucVuRepository.GetAll().Select(x => x.ToDataInfo());
            var coQuan = CoQuanRepository.GetAll().Select(x => x.ToDataInfo());
            var userRole = UserRoleRepository.GetRolesByUserId(id);

            var roles = RoleRepository.GetAll().ToList();
            roles.ForEach(x =>
            {
                userRole.ToList().ForEach(y =>
                {
                    if (y.RoleId == x.Id)
                    {
                        x.IsChecked = true;
                    }
                });
            });


            AddUserViewModel model = new AddUserViewModel
            {
                Id = user.Id,
                FullName = user.HoVaTen,
                UserName = user.UserName,
                IsLocked = user.IsLocked,
                ChucVuId = user.ChucVuId,
                ChucVuInfos = chucvu,
                CoQuanId = user.CoQuanId,
                CoQuanInfos = coQuan,
                CreateDate = user.CreateDate,
                CreatedBy = user.CreatedBy,
                RoleInfos = roles.Select(x => x.ToRoleViewModel()).ToList(),
            };

            return View(model);
        }


        [HttpPost]
        [ActionName("Create")]
        public JsonResult AddUserInfo(AddUserViewModel model)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var pass = TechOfficeConfig.PASSDEFAULT;
                var result = UserRepository.AddUserWithRoles(model.ToUseResult().Update(x =>
                {
                    x.Password = pass;
                    x.CreatedBy = UserName;
                }));

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = result == SaveResult.SUCCESS ? "SB01" : "SB02"
                };
            });
        }

        [HttpPost]
        [ActionName("Edit")]
        public JsonResult EditUserInfo(AddUserViewModel model)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var result = UserRepository.EditUserWtithRoles(model.ToUseResult().Update(x =>
                {
                    x.LastUpdatedBy = UserName;
                }));

                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = result == SaveResult.SUCCESS ? "SB01" : "SB02"
                };
            });
        }

        [HttpPost]
        public JsonResult CheckUserName(string userName)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var userResult = UserRepository.CheckUserName(userName);

                if (userResult != null)
                {
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = "1"
                    };
                }
                else
                {
                    return new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = "0"
                    };
                }
            });
        }
    }
}