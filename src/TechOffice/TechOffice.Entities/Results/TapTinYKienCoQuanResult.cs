using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TapTinYKienCoQuanResult : TapTinResult
    {
        public int YKienCoQuanId { get; set; }

        public YKienCoQuanInfo YKienCoQuanInfo { get; set; }
    }
}