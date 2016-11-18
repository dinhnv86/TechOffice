using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel.CongViec;
using Ninject;
using System.Collections.Generic;
using AnThinhPhat.Entities.Results;

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

        [HttpGet]
        public ActionResult Index(int? userId, int? role, int? trangThaiCongViecId, int? linhVucCongViecId, string noiDungCongViec)
        {
            var model = InitModel();

            if (model.ValueSearch == null)
                model.ValueSearch = new ValueSearchViewModel();

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
            return View();
        }

        [HttpPost, ActionName("Add")]
        public JsonResult AddRecord()
        {
            return ExecuteWithErrorHandling(() => { return new JsonResult(); });
        }

        public ActionResult Detail()
        {
            return View();
        }

        private InitCongViecViewModel InitModel()
        {
            var model = new InitCongViecViewModel
            {
                UsersInfo = UsersRepository.GetAll().Select(x => x.ToDataInfo()),
                LinhVucCongViec = LinhVucCongViecRepository.GetAll().Select(x => x.ToDataInfo()),
                TrangThaiCongViec = TrangThaiCongViecRepository.GetAll().Select(x => x.ToDataInfo())
            };

            return model;
        }

        private IEnumerable<HoSoCongViecResult> Find(ValueSearchViewModel model)
        {
            return HoSoCongViecRepository.Find(new Entities.Searchs.ValueSearchCongViec
            {
                LinhVucCongViecId = model.LinhVucCongViecId,
                NhanVienId = model.UserId,
                NoiDungCongViec = model.NoiDungCongViec,
                Role = model.Role,
                Status = model.Status,
            });
        }
    }
}