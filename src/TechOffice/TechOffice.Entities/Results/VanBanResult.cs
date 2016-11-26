using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class VanBanResult : BaseResult
    {
        public string SoVanBan { get; set; }

        public string TenVanBan { get; set; }

        public DateTime NgayBanHanh { get; set; }

        public string NoiDung { get; set; }

        public string TrichYeu { get; set; }

        public int CoQuanBanHanhId { get; set; }

        public int LoaiVanBanId { get; set; }

        public int LinhVucVanBanId { get; set; }

        public CoQuanBanHanhVanBanInfo CoQuanBanHanhVanBanInfo { get; set; }

        public LoaiVanBanInfo LoaiVanBanInfo { get; set; }

        public LinhVucVanBanInfo LinhVucVanBanInfo { get; set; }

        public IEnumerable<TapTinVanBanResult> Files { get; set; }
    }
}