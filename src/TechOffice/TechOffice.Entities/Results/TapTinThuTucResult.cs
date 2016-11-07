using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class TapTinThuTucResult : TapTinResult
    {
        public int ThuTucId { get; set; }

        public ThuTucInfo ThuTucInfo { get; set; }
    }
}