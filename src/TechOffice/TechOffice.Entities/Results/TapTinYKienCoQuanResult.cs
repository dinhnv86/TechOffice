using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class TapTinYKienCoQuanResult : TapTinResult
    {
        public int YKienCoQuanId { get; set; }

        public YKienCoQuanInfo YKienCoQuanInfo { get; set; }
    }
}