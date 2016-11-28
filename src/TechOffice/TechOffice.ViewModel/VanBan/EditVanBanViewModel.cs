using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AnThinhPhat.ViewModel.VanBan
{
    public class EditVanBanViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_SoVanBan")]
        public string SoVanBan { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_NgayBanHanh")]
        public DateTime NgayBanHanh { get; set; } = DateTime.Now;

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_CoQuanBanHanhVanBan")]
        public int CoQuanBanhHanhVanBanId { get; set; }

        public IEnumerable<CoQuanBanHanhVanBanInfo> CoQuanBanHanhVanBanInfos { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_LinhVucVanBan")]
        public int LinhVucVanBanId { get; set; }

        public IEnumerable<LinhVucVanBanInfo> LinhVucVanBanInfos { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_LoaiVanBan")]
        public int LoaiVanBanId { get; set; }

        public IEnumerable<LoaiVanBanInfo> LoaiVanBanInfos { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_NoiDungVanBan")]
        public string NoiDungVanBan { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_TrichYeuVanBan")]
        [MaxLength(1024, ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "VanBan_AddVanBan_TrichYeuVanBan_MaxLength")]
        public string TrichYeuVanBan { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public IEnumerable<TapTinVanBanResult> TapTinVanBanResults { get; set; }
    }
}