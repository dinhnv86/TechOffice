using System;

namespace TechOffice.Entities.Infos
{
    public class ThuTucInfo : BaseInfo
    {
        public string MaThuTuc { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public string TenThuTuc { get; set; }
    }
}