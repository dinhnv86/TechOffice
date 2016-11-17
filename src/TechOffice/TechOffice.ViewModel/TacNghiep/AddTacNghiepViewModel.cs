using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class AddTacNghiepViewModel
    {
        public string Guid { get; set; }

        [Required(ErrorMessage = "Xin vui lòng nhập ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayTao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayHoanThanh { get; set; }

        [Required(ErrorMessage = "Xin vui lòng nhập ngày hết hạn")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayHetHan { get; set; }

        [Required(ErrorMessage = "Xin vui lòng nhập nội dung")]
        public string NoiDung { get; set; }

        public List<InitCoQuanCoLienQuan> CoQuanInfos { get; set; }

        public string NoiDungYKienTraoDoi { get; set; }

        [Required(ErrorMessage = "Xin vui lòng chọn lĩnh vực tác nghiệp")]
        public int LinhVucId { get; set; }

        public IEnumerable<LinhVucTacNghiepInfo> LinhVucInfos { get; set; }
    }
}
