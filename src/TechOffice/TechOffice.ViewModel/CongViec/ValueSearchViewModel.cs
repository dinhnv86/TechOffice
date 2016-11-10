using AnThinhPhat.Utilities;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class ValueSearchViewModel
    {
        public int? UserId { get; set; }

        public EnumRoleExecute? Role { get; set; }

        public EnumStatus? Status { get; set; }

        public int? LinhVucCongViecId { get; set; }
    }
}
