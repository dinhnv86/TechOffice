using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TacNghiepCoQuanLienQuanResult : BaseResult
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }

        public TacNghiepInfo TacNghiepInfo { get; set; }
    }
}