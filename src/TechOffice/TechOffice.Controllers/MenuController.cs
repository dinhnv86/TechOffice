using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.Menu;
using Ninject;

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
            var model = new InitMenuVanBanViewModel();
            model.LinhVucVanBanInfos = LinhVucVanBanRepository.GetAll().Select(x => x.ToDataInfo());
            model.LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToDataInfo());

            return PartialView("_PartialMenuLeftVanBan", model);
        }

        public PartialViewResult MenuThuTuc()
        {
            var model = new InitMenuThuTucViewModel();
            model.LinhVucThuTucInfos = LinhVucThuTucRepository.GetAll().Select(x => x.ToDataInfo());

            return PartialView("_PartialMenuLeftThuTuc", model);
        }
    }
}