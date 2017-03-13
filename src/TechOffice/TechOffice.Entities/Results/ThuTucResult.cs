using System;
using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class ThuTucResult : BaseResult
    {
        public string NoiDung { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public string TenThuTuc { get; set; }

        //public int CoQuanThucHienId { get; set; }

        public int[] CoQuanThucHienIds { get; set; }

        public int LoaiThuTucId { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }

        public LinhVucThuTucInfo LinhVucThuTucInfo { get; set; }

        public IEnumerable<TapTinThuTucResult> Files { get; set; }
    }
}