using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.VanBan;
using Ninject;

namespace AnThinhPhat.WebUI.Controllers
{
    public class VanBanController : OfficeController
    {
        [Inject]
        public ILoaiVanBanRepository LoaiVanBanRepository { get; set; }

        [Inject]
        public ILinhVucVanBanRepository LinhVucVanRepository { get; set; }

        public ActionResult Index(int? loaiVanBanId = null,
            int? coQuanId = null,
            int? namBanHanhId = null,
            int pagingNumberId = 20,
            string tenVanBan = "",
            bool timTrongSoHieu = false,
            bool timTrongTrichYeu = false,
            bool timTrongNoiDung = false)
        {
            var model = CreateVanBanModel();
            return View(model);
        }

        private InitVanBanViewModel CreateVanBanModel()
        {
            var model = new InitVanBanViewModel
            {
                LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                CoQuanBanHanhInfos = LinhVucVanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo())
            };

            return model;
        }
    }
}