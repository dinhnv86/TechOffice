using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnThinhPhat.Services.Abstracts;
using System.Web.Mvc;
using AnThinhPhat.Utilities;

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

        /// <summary>
        /// Update MucDoHoanThanh of CoQuan
        /// Action just allow with roles (SupperAdmin, Admin) can update this.
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = RoleConstant.SUPPER_ADMIN + TechOfficeConfig.SEPARATE_CHAR + RoleConstant.ADMIN)]
        public void UpdateMucDoHoanThanh(int id)//TinhHinhThucHienId
        {
            ExecuteTryLogException(() =>
            {
                TacNghiepTinhHinhThucHienRepository.UpdateMucDoHoanThanhForTacNghiep(id, UserName);
            });
        }
    }
}
