using System;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class ResultStatisticByCoQuanViewModel
    {
        public string TenCoQuan { get; set; }

        public IEnumerable<ResultCongViecThucHien> NotExecuteResults { get; set; }

        public IEnumerable<ResultCongViecThucHien> ExecutingResults { get; set; }

        public IEnumerable<ResultCongViecThucHien> ExecutedResults { get; set; }

        public IEnumerable<ResultCongViecThucHien> ExecutedOverResults { get; set; }
    }

    public class ResultCongViecThucHien
    {
        public string NoiDungCongViec { get; set; }

        public DateTime? NgayHoanThanh { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime NgayHetHan { get; set; }

        public string LinhVucString { get; set; }

        public string NoiDung { get; set; }

        public string VanBan { get; set; }

        public bool IsDeadline { get; set; }

        public string TrangThai { get; set; }
    }
}