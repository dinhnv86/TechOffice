using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class TacNghiepResult : BaseResult
    {
        public int LinhVucTacNghiepId { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime NgayHetHan { get; set; }

        public DateTime? NgayHoanThanh { get; set; }

        public string NoiDung { get; set; }

        public string NoiDungTraoDoi { get; set; }

        public int? MucDoHoanThanhId { get; set; }

        public LinhVucTacNghiepInfo LinhVucTacNghiepInfo { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }
    }
}