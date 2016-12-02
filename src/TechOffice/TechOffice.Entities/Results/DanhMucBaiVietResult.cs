using System;

namespace AnThinhPhat.Entities.Results
{
    public  class DanhMucBaiVietResult
    {
        public int MaDanhMuc { get; set; }
        public int IdParent { get; set; }
        public string TenDanhMuc { get; set; }
        public string Url { get; set; }
        public string NoiDung { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string Meta_TieuDe { get; set; }
        public string Meta_TuKhoa { get; set; }
        public string Meta_MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool TrangThai { get; set; }
        public bool HienThiTrangChu { get; set; }
        public bool HienThiMenu { get; set; }
        public short? ThuTuHienThi { get; set; }
        public bool? HienThiFooter { get; set; }
    }
}
