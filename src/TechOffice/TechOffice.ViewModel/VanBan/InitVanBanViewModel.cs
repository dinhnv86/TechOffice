using System;
using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.ViewModel.VanBan
{
    public class InitVanBanViewModel
    {
        private IEnumerable<NamBanHanh> _namBanHanh;

        private IEnumerable<PageNumberic> _pagingNumberic;

        public int? CoQuanBanHanhVanBanId { get; set; }

        public int?[] CoQuanBanHanhVanBanIds { get; set; }

        public IEnumerable<CoQuanBanHanhVanBanInfo> CoQuanBanHanhVanBanInfos { get; set; }

        public int? LinhVucVanBanId { get; set; }

        public int?[] LinhVucVanBanIds { get; set; }

        public IEnumerable<LinhVucVanBanInfo> LinhVucVanBanInfos { get; set; }

        public int? LoaiVanBanId { get; set; }

        public int?[] LoaiVanBanIds { get; set; }

        public IEnumerable<LoaiVanBanInfo> LoaiVanBanInfos { get; set; }

        public int? NamBanHanhId { get; set; }

        public int?[] NamBanHanhIds { get; set; }

        public IEnumerable<NamBanHanh> NamBanHanhInfo
        {
            get { return _namBanHanh ?? (_namBanHanh = CreateNam()); }
            internal set { _namBanHanh = value; }
        }

        public int PagingNumberId { get; set; } = 2;

        public IEnumerable<PageNumberic> PagingNumberInfo
        {
            get { return _pagingNumberic ?? (_pagingNumberic = CreatePaging()); }
            internal set { _pagingNumberic = value; }
        }

        public string TenVanBan { get; set; }

        public bool TimTrongSoHieu { get; set; } = false;

        public bool TimTrongTrichYeu { get; set; } = false;

        public bool TimTrongNoiDung { get; set; } = false;

        private static IEnumerable<NamBanHanh> CreateNam()
        {
            for (var i = 0; i < 10; i++)
            {
                int year = DateTime.Now.AddYears(-i).Year;
                yield return new NamBanHanh
                {
                    Id = year,
                    Name = year,
                };
            }
        }

        private static IEnumerable<PageNumberic> CreatePaging()
        {
            for (var i = 1; i < 4; i++)
            {
                yield return new PageNumberic
                {
                    Id = i,
                    Number = i * 10
                };
            }
        }

        public ValueSearchViewModel ValueSearch { get; set; }
    }

    public class NamBanHanh
    {
        public int Id { get; set; }

        public int Name { get; set; }
    }

    public class PageNumberic
    {
        public int Id { get; set; }

        public int Number { get; set; }
    }
}