using System;
using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class BaiVietResult
    {
        public int MaBaiViet { get; set; }
        public int MaDanhMuc { get; set; }
        public string TieuDe { get; set; }
        public string Url { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public string Meta_TieuDe { get; set; }
        public string Meta_TuKhoa { get; set; }
        public string Meta_MoTa { get; set; }
        public int SoLanXem { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool TrangThai { get; set; }

        public IEnumerable<DanhMucBaiVietResult> DanhMucBaiVietResuft { get; set; }
    }
}
