using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class CongViecPhoiHopResult : BaseResult
    {
        public int UserId { get; set; }

        public int HoSoCongViecId { get; set; }

        public HoSoCongViecInfo HoSoCongViec { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}