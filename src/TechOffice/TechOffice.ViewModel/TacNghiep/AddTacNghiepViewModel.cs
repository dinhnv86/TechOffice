using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Resources;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class AddTacNghiepViewModel
    {
        public string Guid { get; set; }

        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "TacNgiep_AddTacNghiepViewModel_NgayTao")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true,
            DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayTao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true,
            DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayHoanThanh { get; set; }

        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "TacNgiep_AddTacNghiepViewModel_NgayHetHan")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true,
            DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayHetHan { get; set; }

        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "TacNgiep_AddTacNghiepViewModel_NoiDung")]
        public string NoiDung { get; set; }

        public List<InitCoQuanCoLienQuan> CoQuanInfos { get; set; }

        public string NoiDungYKienTraoDoi { get; set; }

        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "TacNgiep_AddTacNghiepViewModel_LinhVucTacNghiep")]
        public int LinhVucId { get; set; }

        public IEnumerable<LinhVucTacNghiepInfo> LinhVucInfos { get; set; }
    }
}