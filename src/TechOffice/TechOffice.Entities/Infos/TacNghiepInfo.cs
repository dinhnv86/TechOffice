namespace AnThinhPhat.Entities.Infos
{
    public class TacNghiepInfo : BaseInfo
    {
        public string NoiDung { get; set; }

        public System.DateTime NgayTao { get; set; }

        public System.DateTime? NgayHoanThanh { get; set; }

        public System.DateTime NgayHetHan { get; set; }

        public LinhVucTacNghiepInfo LinhVucTacNghiepInfo { get; set; }
    }
}