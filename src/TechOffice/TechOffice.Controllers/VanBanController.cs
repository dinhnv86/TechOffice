using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.VanBan;
using Ninject;
using AnThinhPhat.Entities.Results;
using PagedList;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.WebUI.Controllers
{
    public class VanBanController : OfficeController
    {
        [Inject]
        public ILoaiVanBanRepository LoaiVanBanRepository { get; set; }

        [Inject]
        public ILinhVucVanBanRepository LinhVucVanRepository { get; set; }

        [Inject]
        public IVanBanRepository VanBanRepository { get; set; }

        [Inject]
        public ITapTinVanBanRepository FilesRepository { get; set; }

        public ActionResult Index(int? loaiVanBanId = null,
            int? coQuanId = null,
            int? namBanHanhId = null,
            int pagingNumberId = 20,
            string tenVanBan = "",
            bool timTrongSoHieu = false,
            bool timTrongTrichYeu = false,
            bool timTrongNoiDung = false)
        {
            var model = CreateVanBanModel(loaiVanBanId,
                coQuanId,
                namBanHanhId,
                pagingNumberId,
                tenVanBan,
                timTrongSoHieu,
                timTrongTrichYeu,
                timTrongNoiDung);
            return View(model);
        }

        public ActionResult List(ValueSearchViewModel search)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = Find(search);
                return PartialView("_PartialPageList", model);
            });
        }

        public ActionResult Detail(int id)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var model = VanBanRepository.Single(id);
                return View(model);
            });
        }

        private InitVanBanViewModel CreateVanBanModel(int? loaiVanBanId = null,
            int? coQuanId = null,
            int? namBanHanhId = null,
            int pagingNumberId = 20,
            string tenVanBan = "",
            bool timTrongSoHieu = false,
            bool timTrongTrichYeu = false,
            bool timTrongNoiDung = false)
        {
            var model = new InitVanBanViewModel
            {
                LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                CoQuanBanHanhInfos = LinhVucVanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                ValueSearch = new ValueSearchViewModel
                {
                    LoaiVanBanId = loaiVanBanId,
                    CoQuanId = coQuanId,
                    NamBanHanhId = namBanHanhId,
                    PagingNumberId = pagingNumberId,
                    TenVanBan = tenVanBan,
                    TimTrongNoiDung = timTrongNoiDung,
                    TimTrongSoHieu = timTrongSoHieu,
                    TimTrongTrichYeu = timTrongTrichYeu,
                    Page = 1,
                },
            };

            return model;
        }

        private IPagedList<VanBanResult> Find(ValueSearchViewModel model)
        {
            var seachAll = VanBanRepository.GetAll();

            if (model.CoQuanId.HasValue)
                seachAll = seachAll.Where(x => x.CoQuanBanHanhId == model.CoQuanId);

            if (model.LoaiVanBanId.HasValue)
                seachAll = seachAll.Where(x => x.LoaiVanBanId == model.LoaiVanBanId);

            if (model.NamBanHanhId.HasValue)
                seachAll = seachAll.Where(x => x.NgayBanHanh.Year == model.NamBanHanhId);

            if (!string.IsNullOrEmpty(model.TenVanBan))
            {
                if (model.TimTrongNoiDung)
                    seachAll = seachAll.Where(x => x.NoiDung.Contains(model.TenVanBan));

                if (model.TimTrongSoHieu)
                    seachAll = seachAll.Where(x => x.SoVanBan.Contains(model.TenVanBan));

                if (model.TimTrongTrichYeu)
                    seachAll = seachAll.Where(x => x.TrichYeu.Contains(model.TenVanBan));
            }

            return seachAll.ToPagedList(model.Page, model.PagingNumberId);
        }

    }
}