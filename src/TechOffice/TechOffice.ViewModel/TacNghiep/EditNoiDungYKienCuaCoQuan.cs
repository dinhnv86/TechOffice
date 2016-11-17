using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class EditNoiDungYKienCuaCoQuan
    {
        public int TacNghiepId { get; set; }

        public int CoQuanId { get; set; }

        public string Guid { get; set; }

        [Required(ErrorMessage = "Xin vui lòng nhập nôi dung phản hồi")]
        public string NoiDung { get; set; }
    }
}
