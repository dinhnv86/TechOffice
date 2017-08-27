using System.ComponentModel;

namespace AnThinhPhat.Utilities
{
    public enum EnumRoleExecute
    {
        [Description("Tất cả")]
        TATCA = 1,

        [Description("Phụ trách")]
        PHUTRACH = 2,

        [Description("Xử lý chính")]
        XULYCHINH = 3,

        [Description("Phối hợp")]
        PHOIHOP = 4
    }

    public enum EnumOrderRoleExecute
    {
        [Description("Không chọn")]
        TATCA = 1,

        [Description("Phụ trách")]
        PHUTRACH = 2,

        [Description("Xử lý chính")]
        XULYCHINH = 3,

        [Description("Phối hợp")]
        PHOIHOP = 4
    }

    public enum EnumStatus
    {
        [Description("Tất cả")]
        TATCA = 1,

        [Description("Chưa xử lý")]
        CHUAXULY = 2,

        [Description("Đang xử lý")]
        DANGXYLY = 3,

        [Description("Đã xử lý")]
        DAXULY = 4
    }

    public enum EnumOrderStatus
    {
        [Description("Không chọn")]
        TATCA = 1,

        [Description("Chưa xử lý")]
        CHUAXULY = 2,

        [Description("Đang xử lý")]
        DANGXYLY = 3,

        [Description("Đã xử lý")]
        DAXULY = 4
    }

    public enum EnumNhacNho
    {
        [Description("Mức 1")]
        LEVEL0 = 1,

        [Description("Mức 2")]
        LEVEL1 = 2,

        [Description("Mức 3")]
        LEVEL2 = 3,
    }

    public enum EnumDanhGiaCongViec
    {
        [Description("Không chọn")]
        LEVEL0 = 0,

        [Description("Mức 1")]
        LEVEL1 = 1,

        [Description("Mức 2")]
        LEVEL2 = 2,

        [Description("Mức 3")]
        LEVEL3 = 3,

        [Description("Mức 4")]
        LEVEL4 = 4,

        [Description("Mức 5")]
        LEVEL5 = 5,
    }
}