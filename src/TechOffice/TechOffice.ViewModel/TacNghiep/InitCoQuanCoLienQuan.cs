using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class InitCoQuanCoLienQuan
    {
        public NhomCoQuanInfo NhomCoQuan { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfo { get; set; }
    }
}
