using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class TacNghiepTinhHinhThucHienResult : BaseResult
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public int ThoiGian { get; set; }

        public string MucDoHoanThanh { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }

        public TacNghiepInfo TacNghiepInfo { get; set; }
    }
}