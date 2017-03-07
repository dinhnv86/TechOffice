namespace AnThinhPhat.ViewModel.VanBan
{
    public class ValueSearchViewModel
    {
        public int? LoaiVanBanId { get; set; }

        public int?[] LoaiVanBanIds { get; set; }

        public int? LinhVucVanBanId { get; set; }

        public int?[] LinhVucVanBanIds { get; set; }

        public int? CoQuanBanHanhVanBanId { get; set; }

        public int?[] CoQuanBanHanhVanBanIds { get; set; }

        public int? NamBanHanhId { get; set; }

        public int?[] NamBanHanhIds { get; set; }

        public int PagingNumberId { get; set; } = 20;

        public string TenVanBan { get; set; }

        public bool TimTrongSoHieu { get; set; }

        public bool TimTrongTrichYeu { get; set; }

        public bool TimTrongNoiDung { get; set; }

        public int Page { get; set; }
    }
}
