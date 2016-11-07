using System;
using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class HoSoCongViecResult : BaseResult
    {
        public DateTime? NgayHetHan { get; set; }

        public int UserPhuTrachId { get; set; }

        public int UserXuLyId { get; set; }

        public int LinhVucCongViecId { get; set; }

        public byte? Status { get; set; }

        public string NoiDung { get; set; }

        public string QuaTrinhXuLy { get; set; }

        public LinhVucCongViecInfo LinhVucCongViec { get; set; }

        public UserInfo UserPhuTrach { get; set; }

        public UserInfo UserXyLy { get; set; }
    }
}