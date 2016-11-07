using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class TacNghiepYKienCoQuanResult : BaseResult
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public string NoiDung { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }
        public TacNghiepInfo TacNghiepInfo { get; set; }
    }
}