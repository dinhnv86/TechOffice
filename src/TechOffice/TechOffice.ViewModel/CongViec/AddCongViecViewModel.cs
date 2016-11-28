using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class AddCongViecViewModel : BaseCongViecViewModel
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

        private List<InitVanBanViewModel> _vanBanLienQuan;
        public List<InitVanBanViewModel> VanBanLienQuanViewModel
        {
            get { return _vanBanLienQuan ?? (_vanBanLienQuan = new List<InitVanBanViewModel>()); }
            set
            {
                _vanBanLienQuan = value;
            }
        }

        private List<InitQuaTrinhXuLyViewModel> _quanTringXuLyViewModel;
        public List<InitQuaTrinhXuLyViewModel> QuaTrinhXuLyViewModel
        {
            get { return _quanTringXuLyViewModel ?? (_quanTringXuLyViewModel = new List<InitQuaTrinhXuLyViewModel>()); }
            set
            {
                _quanTringXuLyViewModel = value;
            }
        }

        public string Guid { get; set; }
    }
}