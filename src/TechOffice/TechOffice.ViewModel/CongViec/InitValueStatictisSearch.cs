using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnThinhPhat.Resources;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitValueStatictisSearchViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CongViec_Statistic_From")]
        public DateTime From { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "CongViec_Statistic_To")]
        public DateTime To { get; set; }

        public int? UserId { get; set; }

        public EnumRoleExecute VaiTroXuLy { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public int? LinhVucCongViecId { get; set; }

        public string NoiDungCongViec { get; set; }

        public string SoVanBan { get; set; }

        public string NoiDungVanBan { get; set; }

        public int? CoQuanId { get; set; }

        //Thu tu hien thi cac cong viec
        public EnumOrderRoleExecute OrderRole { get; set; }

        public EnumOrderStatus OrderStatus { get; set; }

        public int? OrderLinhVucCongViec { get; set; }
        //End thu tu hien thi cac cong viec

        //begin bind list to view
        public IEnumerable<UserInfo> UserInfoNoiVu { get; set; }

        public IEnumerable<LinhVucCongViecInfo> LinhVucCongViecInfos { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }

        public IEnumerable<TrangThaiCongViecInfo> TrangThaiCongViecInfos { get; set; }
        //end bind list to view
    }
}
