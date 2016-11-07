using System;
using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class CongViecQuaTrinhXuLyResult : BaseResult
    {
        public byte GioBanHanh { get; set; }

        public byte PhutBanHanh { get; set; }

        public DateTime? NgayBanHanh { get; set; }

        public string NoiDung { get; set; }

        public string NguoiThem { get; set; }

        public byte? NhacNho { get; set; }

        public int HoSoCongViecId { get; set; }

        public HoSoCongViecInfo HoSoCongViec { get; set; }
    }
}