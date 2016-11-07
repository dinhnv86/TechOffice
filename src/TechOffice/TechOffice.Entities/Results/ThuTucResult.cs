using System;
using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class ThuTucResult : BaseResult
    {
        public string MaThuTuc { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public string TenThuTuc { get; set; }

        public int CoQuanThucHienId { get; set; }

        public int LoaiThuTucId { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }

        public LinhVucThuTucInfo LinhVucThuTucInfo { get; set; }
    }
}