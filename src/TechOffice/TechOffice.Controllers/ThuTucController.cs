using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.ThuTuc;
using Ninject;
using System.Web.Mvc;
using System.Linq;
using AnThinhPhat.Entities;

namespace AnThinhPhat.WebUI.Controllers
{
    public class ThuTucController : OfficeController
    {
        [Inject]
        public ILinhVucThuTucRepository LinhVucThuTucRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        public ActionResult Index(string thuTucCongViec, int? CoQuanId, int? linhVucThuTucId)
        {
            var model = CreateVanBanModel();
            return View(model);
        }

        private InitThuTucViewModel CreateVanBanModel()
        {
            var model = new InitThuTucViewModel();

            //1.Get all linh vuc thu tuc
            model.LinhVucThuTucInfo = LinhVucThuTucRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());

            //2. Get all co quan
            model.CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());

            return model;
        }
    }
}