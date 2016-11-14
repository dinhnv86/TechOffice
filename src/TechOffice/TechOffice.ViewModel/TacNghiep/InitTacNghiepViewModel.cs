using System;
using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.ViewModel.VanBan;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class InitTacNghiepViewModel
    {
        private IEnumerable<NamBanHanh> namBanHanh;

        private ValueSearchViewModel valueSearch;

        public string NhapThongTinTimKiem { get; set; }

        public string TieuChiTimKiem { get; set; }

        public int? NhomCoQuanId { get; set; }
        public IEnumerable<NhomCoQuanInfo> NhomCoQuanInfos { get; set; }

        public int? CoQuanId { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }

        public int? LinhVucTacNghiepId { get; set; }

        public IEnumerable<LinhVucTacNghiepInfo> LinhVucTacNghiepInfo { get; set; }

        public int? MucDoHoanThanhId { get; set; }

        public IEnumerable<MucDoHoanThanhResult> MucDoHoanThanhInfo { get; set; }

        public int? NamBanHanhId { get; set; }

        public IEnumerable<NamBanHanh> NamBanHanhInfo
        {
            get
            {
                if (namBanHanh == null)
                    namBanHanh = CreateNam();
                return namBanHanh;
            }
            private set { namBanHanh = value; }
        }

        public ValueSearchViewModel ValueSearch
        {
            get
            {
                if (valueSearch == null)
                    valueSearch = new ValueSearchViewModel();
                return valueSearch;
            }
            set { valueSearch = value; }
        }

        private IEnumerable<NamBanHanh> CreateNam()
        {
            for (var i = 0; i < 10; i++)
            {
                yield return new NamBanHanh
                {
                    Id = i + 1,
                    Name = DateTime.Now.AddYears(-i).Year
                };
            }
        }
    }
}