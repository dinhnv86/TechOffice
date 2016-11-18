using System;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitQuaTrinhXuLyViewModel
    {
        public int Gio { get; set; }

        public int Phut { get; set; }

        public DateTime Ngay { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public string NguoiThem { get; set; }
    }
}
