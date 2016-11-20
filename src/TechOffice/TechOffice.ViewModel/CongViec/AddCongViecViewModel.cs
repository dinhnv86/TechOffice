﻿using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class AddCongViecViewModel : BaseCongViecViewModel
    {
        public DateTime NgayKhoiTao { get; set; } = DateTime.Now;

        public DateTime? NgayHetHan { get; set; }

        [Required]
        public int UserPhuTrachId { get; set; }

        [Required]
        public int UserXuLyChinhId { get; set; }

        public int? UserPhoiHopId { get; set; }

        [Required]
        public int? LinhVucCongViecId { get; set; }

        [Required]
        public string NoiDungCongViec { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public ValueSearchViewModel ValueSearch { get; set; }

        private List<InitVanBanViewModel> vanBanLienQuan;
        public List<InitVanBanViewModel> VanBanLienQuan
        {
            get
            {
                if (vanBanLienQuan == null)
                    vanBanLienQuan = new List<InitVanBanViewModel>();

                return vanBanLienQuan;
            }
            set
            {
                vanBanLienQuan = value;
            }
        }

        private List<InitQuaTrinhXuLyViewModel> quanTringXuLyViewModel;
        public List<InitQuaTrinhXuLyViewModel> QuaTrinhXuLyViewModel
        {
            get
            {
                if (quanTringXuLyViewModel == null)
                    quanTringXuLyViewModel = new List<InitQuaTrinhXuLyViewModel>();

                return quanTringXuLyViewModel;
            }
            set
            {
                quanTringXuLyViewModel = value;
            }
        }

        public InitVanBanViewModel VanBanViewModel { get; set; }

        public string Guid { get; set; }
    }
}