using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AnThinhPhat.ViewModel.ThuTuc
{
    public class AddThuTucViewModel: ThuTucViewModel
    {
        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_NoiDung"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public string NoiDung { get; set; }

        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_NgayBanHanh"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public DateTime NgayBanHanh { get; set; } = DateTime.Now;

        [MaxLength(1024, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "ThuTuc_AddThuTuc_TenThuTuc_MaxLength")]
        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_TenThuTuc"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public string TenThuTuc { get; set; }

        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_CoQuanThucHien"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public int CoQuanThucHienId { get; set; }

        [Required(ErrorMessageResourceName = ("ThuTuc_AddThuTuc_LinhVucThuTuc"), ErrorMessageResourceType = typeof(Resources.Messages))]
        public int LinhVucThuTucId { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
