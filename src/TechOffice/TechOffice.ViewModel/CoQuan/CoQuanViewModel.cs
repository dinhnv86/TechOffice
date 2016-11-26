using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Resources;

namespace AnThinhPhat.ViewModel.CoQuan
{
    public class CoQuanViewModel : BaseDataViewModel
    {
        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "CoQuan_CoQuanViewModel_CoQuanId")]
        public int NhomCoQuanId { get; set; }

        public NhomCoQuanInfo NhomCoQuanInfo { get; set; }

        public IEnumerable<NhomCoQuanInfo> NhomCoQuanInfos { get; set; }
    }
}