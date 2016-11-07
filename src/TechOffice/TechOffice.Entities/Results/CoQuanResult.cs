using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.Entities.Results
{
    public class CoQuanResult : DataResult
    {
        public int NhomCoQuanId { get; set; }

        public NhomCoQuanInfo NhomCoQuan { get; set; }
    }
}