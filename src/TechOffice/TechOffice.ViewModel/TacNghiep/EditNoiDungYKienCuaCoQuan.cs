using System.ComponentModel.DataAnnotations;
using AnThinhPhat.Resources;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class EditNoiDungYKienCuaCoQuan
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public string Guid { get; set; }

        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "TacNghiep_EditNoiDungYKienCuaCoQuan_NoiDung")]
        public string NoiDung { get; set; }
    }
}