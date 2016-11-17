using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnThinhPhat.Services.Abstracts;

namespace AnThinhPhat.WebUI.Controllers
{
    public class TacNghiepTinhHinhThucHienController : OfficeController
    {
        [Inject]
        public ITacNghiepTinhHinhThucHienRepository TacNghiepTinhHinhThucHienRepository { get; set; }

        /// <summary>
        /// When SupperAdmin or Admin check in GUI into Detail TacNghiep Page then will update to DB
        /// </summary>
        /// <param name="tacNghiepId"></param>
        /// <param name="coQuanId"></param>
        public void UpdateCoQuanLienQuan(int tacNghiepId, int coQuanId)
        {
            ExecuteTryLogException(() =>
            {
                TacNghiepTinhHinhThucHienRepository.UpdateCoQuanLienQuan(tacNghiepId, coQuanId, UserName);
            });
        }
    }
}
