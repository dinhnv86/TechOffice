using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class DetailTacNghiepViewModel
    {
        public int Id { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime? NgayHoanThanh { get; set; }

        public DateTime NgayHetHan { get; set; }

        public string NoiDung { get; set; }

        public IEnumerable<TacNghiepTinhHinhThucHienResult> CoQuanInfos { get; set; }

        public string NoiDungYKienTraoDoi { get; set; }

        public int LinhVucTacNghiepId { get; set; }

        public IEnumerable<LinhVucTacNghiepInfo> LinhVucTacNghiepInfo { get; set; }

        public string JsonFiles { get; set; }

        public bool IsRoleAdmin { get; set; }

        public IEnumerable<InitCoQuanCoLienQuan> NhomCoQuanCoLienQuanInfo { get; set; }
    }
}
