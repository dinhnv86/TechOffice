using AnThinhPhat.Entities.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnThinhPhat.ViewModel.VanBan
{
    public class InitVanBanViewModel
    {
        public int? CoQuanId { get; set; }

        public IEnumerable<LinhVucVanBanInfo> CoQuanBanHanhInfos { get; set; }

        public int? LoaiVanBanId { get; set; }
        public IEnumerable<LoaiVanBanInfo> LoaiVanBanInfos { get; set; }

        public int? NamBanHnahId { get; set; }
        private IEnumerable<NamBanHanh> namBanHanh;
        public IEnumerable<NamBanHanh> NamBanHanhInfo
        {
            get
            {
                if (namBanHanh == null)
                    namBanHanh = CreateNam();
                return namBanHanh;
            }
            private set
            {
                namBanHanh = value;
            }
        }

        public int PagingNumberId { get; set; } = 2;
        private IEnumerable<PageNumberic> pagingNumberic;
        public IEnumerable<PageNumberic> PagingNumberInfo
        {
            get
            {
                if (pagingNumberic == null)
                    pagingNumberic = CreatePaging();
                return pagingNumberic;
            }
            private set
            {
                pagingNumberic = value;
            }
        }

        public string TenVanBan { get; set; }

        public bool TimTrongSoHieu { get; set; } = false;

        public bool TimTrongTrichYeu { get; set; } = false;

        public bool TimTrongNoiDung { get; set; } = false;

        private IEnumerable<NamBanHanh> CreateNam()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new NamBanHanh
                {
                    Id = i + 1,
                    Name = DateTime.Now.AddYears(-i).Year,
                };
            }
        }

        private IEnumerable<PageNumberic> CreatePaging()
        {
            for (int i = 1; i < 4; i++)
            {
                yield return new PageNumberic
                {
                    Id = i,
                    Number = i * 10,
                };
            }
        }
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
