using AnThinhPhat.Entities.Results;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.ThuTuc
{
    public class LinhVucThuTucViewModel : BaseDataViewModel
    {
        public int? ParentId { get; set; }

        public int? Position { get; set; }

        public IEnumerable<LinhVucThuTucResult> LinhVucThuTuces { get; set; }
    }
}