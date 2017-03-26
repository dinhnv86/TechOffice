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
        public ICoQuanBanHanhVanBanRepository CoQuanBanHanhVanBanRepository { get; set; }

        [Inject]
        public ILinhVucThuTucRepository LinhVucThuTucRepository { get; set; }

        [Inject]
        public INewsCategoryRepository NewsCategoryRepository { get; set; }

        [Inject]
        public IPageReferenceRepository PageReferenceRepository { get; set; }

        public PartialViewResult MenuVanBan()
        {
            var model = new InitMenuVanBanViewModel();
            model.CoQuanBanHanhVanBanInfos = CoQuanBanHanhVanBanRepository.GetAll().Select(x => x.ToDataInfo());
            model.LoaiVanBanInfos = LoaiVanBanRepository.GetAll().Select(x => x.ToDataInfo());

            return PartialView("_PartialMenuLeftVanBan", model);
        }

        public PartialViewResult MenuThuTuc()
        {
            var model = new InitMenuThuTucViewModel();
            model.LinhVucThuTucResults = LinhVucThuTucRepository.GetAll();

            return PartialView("_PartialMenuLeftThuTuc", model);
        }

        public PartialViewResult MenuDanhMuc()
        {
            var model = new InitMenuNewsCategoryViewModel()
            {
                NewsCategories = NewsCategoryRepository.GetAll()
            };

            return PartialView("~/Views/Shared/Menu/_MenuDanhMuc.cshtml", model);
        }

        public PartialViewResult MenuPhoto()
        {
            var model = new InitMenuPageReferenceViewModel()
            {
                PageReferenceResults = PageReferenceRepository.GetAll()
            };

            return PartialView("~/Views/Shared/Menu/MenuPhoto.cshtml", model);
        }
    }
}