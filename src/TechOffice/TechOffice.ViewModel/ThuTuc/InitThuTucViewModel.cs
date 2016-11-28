using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.ViewModel.ThuTuc
{
    public class InitThuTucViewModel : ThuTucViewModel
    {
        public string ThuTucCongViec { get; set; }

        public int? CoQuanId { get; set; }

        public int? LinhVucThuTucId { get; set; }

        public ValueSearchViewModel ValueSearch { get; set; }
    }
}