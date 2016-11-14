using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class ResultStatisticByCoQuanViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ResultCongViecThucHien> NotExecuteResults { get; set; }

        public IEnumerable<ResultCongViecThucHien> ExecutingResults { get; set; }

        public IEnumerable<ResultCongViecThucHien> ExecutedResults { get; set; }
    }

    public class ResultCongViecThucHien
    {
        public string Name { get; set; }

        public bool IsDeadline { get; set; }
    }
}
