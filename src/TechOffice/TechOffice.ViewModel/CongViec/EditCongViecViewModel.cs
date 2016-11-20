using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class EditCongViecViewModel : BaseCongViecViewModel
    {
        public DateTime NgayKhoiTao { get; set; } = DateTime.Now;

        public DateTime? NgayHetHan { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "CongViec_Add_UserPhuTrach")]
        public int UserPhuTrachId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "CongViec_Add_UserXuLy")]
        public int UserXuLyChinhId { get; set; }

        public int[] UsersPhoiHopId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "CongViec_Add_LinhVucCongViec")]
        public int LinhVucCongViecId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "CongViec_Add_NoiDungCongViec")]
        public string NoiDungCongViec { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public IList<CongViecVanBanResult> VanBanLienQuanViewModel
        {
            get; set;
        }

        public IList<CongViecQuaTrinhXuLyResult> QuaTrinhXuLyViewModel
        {
            get; set;
        }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }

        public int? CoQuanIdTemp { get; set; }
    }
}