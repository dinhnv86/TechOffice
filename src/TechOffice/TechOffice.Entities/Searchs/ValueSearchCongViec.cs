using AnThinhPhat.Utilities;

namespace AnThinhPhat.Entities.Searchs
{
    public class ValueSearchCongViec
    {
        public int? NhanVienId { get; set; }

        public EnumRoleExecute? Role { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public int? LinhVucCongViecId { get; set; }

        public string NoiDungCongViec { get; set; }
    }
}
