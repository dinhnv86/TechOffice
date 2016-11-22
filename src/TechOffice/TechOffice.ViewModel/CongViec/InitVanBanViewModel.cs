using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitVanBanViewModel
    {
        public string SoVanBan { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Ngay { get; set; } = DateTime.Now;

        public string NoiDung { get; set; }

        public int? CoQuanId { get; set; }

        public string NameCoQuan { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }
    }
}
