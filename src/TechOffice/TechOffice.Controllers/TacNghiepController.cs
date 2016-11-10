using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.ThuTuc;
using Ninject;
using System.Web.Mvc;
using System.Linq;
using AnThinhPhat.Entities;
using AnThinhPhat.ViewModel.TacNghiep;

namespace AnThinhPhat.WebUI.Controllers
{
    public class TacNghiepController : OfficeController
    {
        [Inject]
        public ILinhVucTacNghiepRepository LinhVucTacNghiepRepository { get; set; }

        [Inject]
        public INhomCoQuanRepository NhomCoQuanRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public IMucDoHoanThanhRepository MucDoHoanThanhRepository { get; set; }

        [HttpGet]
        public ActionResult Index(int? nhomCoquanId,
            int? coQuanId,
            int? linhVucTacNghiepId,
            int? mucDoHoanThanhId,
            int? namBanHanhId,
            string nhapThongTinTimKiem,
            string tieuChiTimKiem)
        {
            var model = CreateTacNghiepModel();

            model.ValueSearch.NhomCoquanId = nhomCoquanId;
            model.ValueSearch.CoQuanId = coQuanId;
            model.ValueSearch.MucDoHoanThanhId = mucDoHoanThanhId;
            model.ValueSearch.NamBanHanhId = namBanHanhId;
            model.ValueSearch.NhapThongTinTimKiem = nhapThongTinTimKiem;
            model.ValueSearch.TieuChiTimKiem = tieuChiTimKiem;

            return View(model);
        }

        public ActionResult List(ValueSearchViewModel model)
        {
            if (model == null)
                return View("_PartialPageList", null);

            //Execute data
            return View("_PartialPageList", model);
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

        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost, ActionName("Add")]
        public JsonResult AddRecord()
        {
            return ExecuteWithErrorHandling(() =>
            {
                return new JsonResult
                {

                };

            });
        }

        private InitTacNghiepViewModel CreateTacNghiepModel()
        {
            var model = new InitTacNghiepViewModel();

            model.LinhVucTacNghiepInfo = LinhVucTacNghiepRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());
            model.CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());
            model.NhomCoQuanInfos = NhomCoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());
            model.MucDoHoanThanhInfo = MucDoHoanThanhRepository.GetAll();

            return model;
        }
    }
}