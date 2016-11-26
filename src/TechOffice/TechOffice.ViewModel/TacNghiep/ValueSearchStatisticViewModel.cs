using System;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class ValueSearchStatisticViewModel
    {
        public int? NhomCoquanId { get; set; }

        public int? CoQuanId { get; set; }

        public int? LinhVucTacNghiepId { get; set; }

        public int? MucDoHoanThanhId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}