using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.ThuTuc;
using Ninject;
using PagedList;
using AnThinhPhat.Utilities;
using AnThinhPhat.Entities.Results;

namespace AnThinhPhat.WebUI.Controllers
{
    public class ThuTucController : OfficeController
    {
        [Inject]
        public ILinhVucThuTucRepository LinhVucThuTucRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public IThuTucRepository ThuTucRepository { get; set; }

        [HttpGet]
        public ActionResult Index(string thuTucCongViec, int? coQuanId, int? linhVucThuTucId)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = CreateVanBanModel(thuTucCongViec, coQuanId, linhVucThuTucId);
                return View(model);
            });
        }

        public ActionResult List(ValueSearchViewModel search)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = Find(search);
                return PartialView("_PartialPageList", model);
            });
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = ThuTucRepository.Single(id);
                return View(model);
            });
        }

        private InitThuTucViewModel CreateVanBanModel(string thuTucCongViec, int? coQuanId, int? linhVucCongViecId)
        {
            var model = new InitThuTucViewModel
            {
                LinhVucThuTucInfo = LinhVucThuTucRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                ValueSearch = new ValueSearchViewModel
                {
                    ThuTucCongViec = thuTucCongViec,
                    CoQuanId = coQuanId,
                    LinhVucThuTucId = linhVucCongViecId,
                    Page = 1,
                },
            };

            return model;
        }

        private IPagedList<ThuTucResult> Find(ValueSearchViewModel model)
        {
            var seachAll = ThuTucRepository.GetAll();
            if (!string.IsNullOrEmpty(model.ThuTucCongViec))
                seachAll = seachAll.Where(x => x.TenThuTuc.Contains(model.ThuTucCongViec));

            if (model.CoQuanId.HasValue)
                seachAll = seachAll.Where(x => x.CoQuanThucHienId == model.CoQuanId);

            if (model.LinhVucThuTucId.HasValue)
                seachAll = seachAll.Where(x => x.LoaiThuTucId == model.LinhVucThuTucId);

            return seachAll.ToPagedList(model.Page, TechOfficeConfig.PAGESIZE);
        }
    }
}