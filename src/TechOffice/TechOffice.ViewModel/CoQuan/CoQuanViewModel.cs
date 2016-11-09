using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.CoQuan
{
    public class CoQuanViewModel : BaseDataViewModel
    {
        [Required]
        public int NhomCoQuanId { get; set; }

        public NhomCoQuanInfo NhomCoQuanInfo { get; set; }

        public IEnumerable<NhomCoQuanInfo> NhomCoQuanInfos { get; set; }
    }
}
