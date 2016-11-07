using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TapTinTacNghiepResult : TapTinResult
    {
        public int TacNghiepId { get; set; }

        public TacNghiepInfo TacNghiepInfo { get; set; }
    }
}