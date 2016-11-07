using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TapTinCongViecResult : TapTinResult
    {
        public int HoSoCongViecId { get; set; }

        public HoSoCongViecInfo HoSoCongViecInfo { get; set; }
    }
}