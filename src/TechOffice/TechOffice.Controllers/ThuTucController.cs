using System.Linq;
using System.Web.Mvc;
using AnThinhPhat.Entities;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.ThuTuc;
using Ninject;

namespace AnThinhPhat.WebUI.Controllers
{
    public class ThuTucController : OfficeController
    {
        [Inject]
        public ILinhVucThuTucRepository LinhVucThuTucRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        public ActionResult Index(string thuTucCongViec, int? coQuanId, int? linhVucThuTucId)
        {
            var model = CreateVanBanModel();
            return View(model);
        }

        private InitThuTucViewModel CreateVanBanModel()
        {
            var model = new InitThuTucViewModel
            {
                LinhVucThuTucInfo = LinhVucThuTucRepository.GetAll().Select(x => x.ToIfNotNullDataInfo()),
                CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo())
            };

            return model;
        }
    }
}