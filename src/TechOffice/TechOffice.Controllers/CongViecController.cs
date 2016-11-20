using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel.CongViec;
using Ninject;
using System.Collections.Generic;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.ViewModel;
using PagedList;
using System;

namespace AnThinhPhat.WebUI.Controllers
{
    [Authorize]
    public class CongViecController : OfficeController
    {
        [Inject]
        public IUsersRepository UsersRepository { get; set; }

        [Inject]
        public ICongViecQuaTrinhXuLyRepository QuaTrinhXuLyRepository { get; set; }

        [Inject]
        public ILinhVucCongViecRepository LinhVucCongViecRepository { get; set; }

        [Inject]
        public ITrangThaiCongViecRepository TrangThaiCongViecRepository { get; set; }

        [Inject]
        public IHoSoCongViecRepository HoSoCongViecRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [HttpGet]
        public ActionResult Index(int? userId, int? role, int? trangThaiCongViecId, int? linhVucCongViecId, string noiDungCongViec)
        {
            var init = InitModel();

            var model = new InitCongViecViewModel
            {
                UsersInfos = init.UsersInfos,
                LinhVucCongViecInfos = init.LinhVucCongViecInfos,
                TrangThaiCongViecInfos = init.TrangThaiCongViecInfos,
            };

            if (model.ValueSearch == null)
                model.ValueSearch = new ValueSearchViewModel();

            if (userId == null)
                model.ValueSearch.UserId = UserId;//set current user 
            else
                model.ValueSearch.UserId = userId;

            if (role != null)
                model.ValueSearch.Role = (EnumRoleExecute)role;
            else
                model.ValueSearch.Role = EnumRoleExecute.TATCA;

            if (trangThaiCongViecId != null)
                model.ValueSearch.Status = (EnumStatus)trangThaiCongViecId;
            else
                model.ValueSearch.Status = EnumStatus.TATCA;

            model.ValueSearch.LinhVucCongViecId = linhVucCongViecId;
            model.ValueSearch.NoiDungCongViec = noiDungCongViec;
            model.ValueSearch.Page = 1;

            return View(model);
        }

        public ActionResult List(ValueSearchViewModel model)
        {
            if (model.UserId == null)
            {
                //Get current UserId
                model.UserId = UserId;
            }

            var result = Find(model);

            return View("_PartialPageList", result);
        }

        [HttpGet]
        public ActionResult Statistic()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var init = InitModel();
            var model = new AddCongViecViewModel
            {
                UsersInfos = init.UsersInfos,
                LinhVucCongViecInfos = init.LinhVucCongViecInfos,
                TrangThaiCongViecInfos = init.TrangThaiCongViecInfos,
                VanBanLienQuan = new List<InitVanBanViewModel>
                {
                    new InitVanBanViewModel
                    {
                        CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToDataInfo()),
                    }
                },
                QuaTrinhXuLyViewModel = new List<InitQuaTrinhXuLyViewModel>
                {
                   new InitQuaTrinhXuLyViewModel
                   {
                       Gio=0,
                       Ngay=new System.DateTime(),
                       NoiDung =string.Empty,
                       NguoiThem=UserName,
                   },
                },
                Guid = Guid.NewGuid().ToString()
            };

            return View(model);
        }

        [HttpPost, ActionName("Add")]
        public JsonResult AddRecord(AddCongViecViewModel model)
        {
            return ExecuteWithErrorHandling(() => { return new JsonResult(); });
        }

        public ActionResult Detail()
        {
            return View();
        }

        private BaseCongViecViewModel InitModel()
        {
            var model = new BaseCongViecViewModel
            {
                UsersInfos = UsersRepository.GetAll().Select(x => x.ToDataInfo()),
                LinhVucCongViecInfos = LinhVucCongViecRepository.GetAll().Select(x => x.ToDataInfo()),
                TrangThaiCongViecInfos = TrangThaiCongViecRepository.GetAll().Select(x => x.ToDataInfo()),
            };

            return model;
        }

        private IPagedList<HoSoCongViecResult> Find(ValueSearchViewModel model)
        {
            var query = HoSoCongViecRepository.Find(model.ToValueSearch());
            return query.ToPagedList(model.Page, TechOfficeConfig.PAGESIZE);
        }
    }
}