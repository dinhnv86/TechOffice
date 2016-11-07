using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class TapTinTacNghiepResult : TapTinResult
    {
        public int TacNghiepId { get; set; }

        public TacNghiepInfo TacNghiepInfo { get; set; }
    }
}