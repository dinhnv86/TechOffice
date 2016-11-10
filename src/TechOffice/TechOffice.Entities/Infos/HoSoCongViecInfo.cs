using System;

namespace AnThinhPhat.Entities.Infos
{
    public class HoSoCongViecInfo : BaseInfo
    {
        public DateTime? NgayHetHan { get; set; }

        //Should change to enum
        public TrangThaiCongViecInfo TrangThai { get; set; }

        public string NoiDung { get; set; }
    }
}