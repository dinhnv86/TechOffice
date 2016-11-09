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
        public ILinhVucCongViecRepository LinhVucCongViecRepository { get; set; }

        [Inject]
        public INhomCoQuanRepository NhomCoQuanRepository { get; set; }

        [Inject]
        public ICoQuanRepository CoQuanRepository { get; set; }

        [Inject]
        public IMucDoHoanThanhRepository MucDoHoanThanhRepository { get; set; }

        public ActionResult Index()
        {
            var model = CreateTacNghiepModel();
            return View(model);
        }

        private InitTacNghiepViewModel CreateTacNghiepModel()
        {
            var model = new InitTacNghiepViewModel();

            //1.Get all linh vuc thu tuc
            model.LinhVucThuTucInfo = LinhVucCongViecRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());
            model.CoQuanInfos = CoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());
            model.NhomCoQuanInfos = NhomCoQuanRepository.GetAll().Select(x => x.ToIfNotNullDataInfo());
            model.MucDoHoanThanhInfo = MucDoHoanThanhRepository.GetAll();

            return model;
        }
    }
}