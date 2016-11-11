using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AnThinhPhat.Services.Abstracts;
using Ninject;
using AnThinhPhat.ViewModel.Menu;
using AnThinhPhat.Entities;

namespace AnThinhPhat.WebUI.Controllers
{
    public class MenuController : OfficeController
    {
        [Inject]
        public ILoaiVanBanRepository LoaiVanBanRepository { get; set; }

        [Inject]
        public ILinhVucVanBanRepository LinhVucVanBanRepository { get; set; }

        [Inject]
        public ILinhVucThuTucRepository LinhVucThuTucRepository { get; set; }

        public PartialViewResult MenuVanBan()
        {
            InitMenuVanBanViewModel model = new InitMenuVanBanViewModel();
            model.LinhVucVanBanInfos = LinhVucVanBanRepository.GetAll().Select(x => x.ToDataInfo());
            model.LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToDataInfo());

            return PartialView("_PartialMenuLeftVanBan", model);
        }

        public PartialViewResult MenuThuTuc()
        {
            InitMenuThuTucViewModel model = new InitMenuThuTucViewModel();
            model.LinhVucThuTucInfos = LinhVucThuTucRepository.GetAll().Select(x => x.ToDataInfo());

            return PartialView("_PartialMenuLeftThuTuc", model); 
        }
    }
}
