namespace AnThinhPhat.ViewModel.VanBan
{
    public class ValueSearchViewModel
    {
        public int? LoaiVanBanId { get; set; }

        public int? CoQuanId { get; set; }

        public int? NamBanHanhId { get; set; }

        public int PagingNumberId { get; set; } = 20;

        public string TenVanBan { get; set; }

        public bool TimTrongSoHieu { get; set; }

        public bool TimTrongTrichYeu { get; set; }

        public bool TimTrongNoiDung { get; set; }

        public int Page { get; set; }
    }
}
