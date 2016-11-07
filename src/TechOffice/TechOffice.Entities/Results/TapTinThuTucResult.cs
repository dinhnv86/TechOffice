using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TapTinThuTucResult : TapTinResult
    {
        public int ThuTucId { get; set; }

        public ThuTucInfo ThuTucInfo { get; set; }
    }
}