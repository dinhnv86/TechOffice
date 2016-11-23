using AnThinhPhat.Utilities;
using System;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class ValueSearchViewModel
    {
        public int? UserId { get; set; }

        public EnumRoleExecute? Role { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public int? LinhVucCongViecId { get; set; }

        public string NoiDungCongViec { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public string SoVanBan { get; set; }

        public string NoiDungVanBan { get; set; }

        public int? CoQuanId { get; set; }

        public int Page { get; set; }
    }
}