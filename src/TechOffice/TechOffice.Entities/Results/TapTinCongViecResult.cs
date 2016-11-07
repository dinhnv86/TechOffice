using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class TapTinCongViecResult : TapTinResult
    {
        public int HoSoCongViecId { get; set; }

        public HoSoCongViecInfo HoSoCongViecInfo { get; set; }
    }
}