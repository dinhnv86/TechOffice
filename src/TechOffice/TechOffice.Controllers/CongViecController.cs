using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel.CongViec;
using Ninject;

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

        [HttpGet]
        public ActionResult Index(int? userId, int? role, int? status, int? linhVucCongViecId)
        {
            var model = InitModel();

            if (model.ValueSearch == null)
                model.ValueSearch = new ValueSearchViewModel();

            model.ValueSearch.UserId = userId ?? 0;
            if (role != null)
                model.ValueSearch.Role = (EnumRoleExecute) role;

            if (status != null)
                model.ValueSearch.Status = (EnumStatus) status;

            model.ValueSearch.LinhVucCongViecId = linhVucCongViecId ?? 0;

            return View(model);
        }

        public ActionResult List(ValueSearchViewModel model)
        {
            if (model == null)
                return View("_PartialPageList");

            return View("_PartialPageList");
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
    }
}