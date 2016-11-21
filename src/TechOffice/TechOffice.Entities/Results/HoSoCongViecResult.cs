using System;
using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class HoSoCongViecResult : BaseResult
    {
        public DateTime? NgayHetHan { get; set; }

        public DateTime NgayTao { get; set; }

        public int UserPhuTrachId { get; set; }

        public int UserXuLyId { get; set; }

        public int LinhVucCongViecId { get; set; }

        public byte? Status { get; set; }

        public string NoiDung { get; set; }

        public byte? QuaTrinhXuLy { get; set; }

        public LinhVucCongViecInfo LinhVucCongViec { get; set; }

        public UserInfo UserPhuTrach { get; set; }

        public UserInfo UserXyLy { get; set; }

        public IEnumerable<CongViecPhoiHopResult> CongViecPhoiHopResult { get; set; }

        public IEnumerable<CongViecQuaTrinhXuLyResult> CongViecQuaTrinhXuLyResult { get; set; }

        public IEnumerable<CongViecVanBanResult> CongViecVanBanResults { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public TrangThaiCongViecInfo TrangThaiCongViecInfo { get; set; }
    }
}