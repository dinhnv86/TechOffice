using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TapTinVanBanResult : TapTinResult
    {
        public int VanBanId { get; set; }

        public VanBanInfo VanBanInfo { get; set; }
    }
}