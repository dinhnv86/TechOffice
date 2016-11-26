using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities
{
    public class TapTinResult : BaseResult
    {
        public int UserUploadId { get; set; }

        public string Url { get; set; }

        public UserInfo UserInfo { get; set; }

        public string Path { get; set; }

        public string FileName { get; set; }
    }
}