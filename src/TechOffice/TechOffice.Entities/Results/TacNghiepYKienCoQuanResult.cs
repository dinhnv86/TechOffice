using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TacNghiepYKienCoQuanResult : BaseResult
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public string NoiDung { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }

        public TacNghiepInfo TacNghiepInfo { get; set; }

        public string JsonFiles { get; set; }

        public string NoiDungTraLoi { get; set; }

        public int? UserIdTraLoi { get; set; }
    }
}