using TechOffice.Entities.Infos;

namespace TechOffice.Entities
{
    public class TapTinResult : BaseResult
    {
        public int UserUploadId { get; set; }

        public string Url { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}