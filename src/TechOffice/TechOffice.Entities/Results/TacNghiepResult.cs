using AnThinhPhat.Entities.Infos;
using System;

namespace AnThinhPhat.Entities.Results
{
    public class TacNghiepResult : BaseResult
    {
        public int LinhVucTacNghiepId { get; set; }

        public DateTime NgayHetHan { get; set; }

        public DateTime? NgayHoanThanh { get; set; }

        public string NoiDung { get; set; }

        public string NoiDungTraoDoi { get; set; }

        public LinhVucTacNghiepInfo LinhVucTacNghiepInfo { get; set; }
    }
}