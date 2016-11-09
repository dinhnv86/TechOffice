using System.Web.Mvc;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel;
using Ninject;
using PagedList;
using System;
using System.Threading.Tasks;
using System.Net;
using AnThinhPhat.Entities.Results;
using System.Linq;
using AnThinhPhat.ViewModel.VanBan;
using AnThinhPhat.Entities;

namespace AnThinhPhat.WebUI.Controllers
{
    public class VanBanController : OfficeController
    {
        [Inject]
        public ILoaiVanBanRepository LoaiVanBanRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

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
            var model = new InitVanBanViewModel();

            //1.Get all loai van van
            model.LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());

            //2. Get all co quan
            model.CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());

            return model;
        }
    }
}