using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class TacNghiepTinhHinhThucHienResult : BaseResult
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public int ThoiGian { get; set; }

        public int? MucDoHoanThanhId { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }

        public TacNghiepInfo TacNghiepInfo { get; set; }

        public MucDoHoanThanhResult MucDoHoanThanhInfo { get; set; }
    }
}