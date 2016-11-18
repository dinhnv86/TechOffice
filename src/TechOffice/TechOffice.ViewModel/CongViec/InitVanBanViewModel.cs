using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitVanBanViewModel
    {
        [Required]
        public string SoVanBan { get; set; }

        [Required]
        public DateTime Ngay { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        public int CoQuanId { get; set; }

        public string NameCoQuan { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }
    }
}
