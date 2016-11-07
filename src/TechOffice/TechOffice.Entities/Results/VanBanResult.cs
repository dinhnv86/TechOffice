using System;
using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class VanBanResult : BaseResult
    {
        public string SoVanBan { get; set; }

        public string TenVanBan { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public int CoQuanBanHanhId { get; set; }

        public int LoaiVanBanId { get; set; }

        public int LinhVucVanBanId { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }

        public LoaiVanBanInfo LoaiVanBanInfo { get; set; }

        public LinhVucVanBanInfo LinhVucVanBanInfo { get; set; }
    }
}