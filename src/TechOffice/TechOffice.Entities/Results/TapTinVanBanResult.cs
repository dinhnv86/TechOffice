using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class TapTinVanBanResult : TapTinResult
    {
        public int VanBanId { get; set; }

        public VanBanInfo VanBanInfo { get; set; }
    }
}