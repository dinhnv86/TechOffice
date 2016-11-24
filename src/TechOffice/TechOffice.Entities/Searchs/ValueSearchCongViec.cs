using AnThinhPhat.Utilities;
using System;

namespace AnThinhPhat.Entities.Searchs
{
    public class ValueSearchCongViec
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public int? NhanVienId { get; set; }

        public EnumRoleExecute? Role { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public int? LinhVucCongViecId { get; set; }

        public string NoiDungCongViec { get; set; }

        public string SoVanBan { get; set; }

        public string NoiDungVanBan { get; set; }

        public int? CoQuanId { get; set; }

    }
}
