using System;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class ResultStatisticByCongViecViewModel
    {
        public DateTime NgayTao { get; set; }

        public string Name { get; set; }

        public IEnumerable<ResultCoQuanThucHien> NotExecuteResults { get; set; }

        public IEnumerable<ResultCoQuanThucHien> ExecutingResults { get; set; }

        public IEnumerable<ResultCoQuanThucHien> ExecutedResults { get; set; }
    }

    public class ResultCoQuanThucHien
    {
        public string Name { get; set; }

        public DateTime? NgayHoanThanh { get; set; }
    }
}