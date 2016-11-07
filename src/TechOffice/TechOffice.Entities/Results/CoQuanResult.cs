using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class CoQuanResult : DataResult
    {
        public int NhomCoQuanId { get; set; }

        public NhomCoQuanInfo NhomCoQuan { get; set; }
    }
}