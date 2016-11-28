using System;
using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.ViewModel.VanBan;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class InitTacNghiepViewModel
    {
        private IEnumerable<NamBanHanh> _namBanHanh;

        private ValueSearchViewModel _valueSearch;

        public string NhapThongTinTimKiem { get; set; }

        public bool SearchTypeValue { get; set; } = true;

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
            get { return _namBanHanh ?? (_namBanHanh = CreateNam()); }
            private set { _namBanHanh = value; }
        }

        public ValueSearchViewModel ValueSearch
        {
            get { return _valueSearch ?? (_valueSearch = new ValueSearchViewModel()); }
            set { _valueSearch = value; }
        }

        private static IEnumerable<NamBanHanh> CreateNam()
        {
            for (var i = 0; i < 10; i++)
            {
                yield return new NamBanHanh
                {
                    Id = DateTime.Now.AddYears(-i).Year,
                    Name = DateTime.Now.AddYears(-i).Year
                };
            }
        }
    }
}