using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.ThuTuc
{
    public class ThuTucViewModel
    {
        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }

        public IEnumerable<LinhVucThuTucInfo> LinhVucThuTucInfo { get; set; }
    }
}
