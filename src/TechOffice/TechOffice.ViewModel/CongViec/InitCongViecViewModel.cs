using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitCongViecViewModel
    {
        public int? UserId { get; set; }

        public IEnumerable<UserInfo> UsersInfo { get; set; }

        public IEnumerable<CongViecQuaTrinhXuLyResult> QuaTrinhXyLy { get; set; }

        public int? LinhVucCongViecId { get; set; }
        public IEnumerable<LinhVucCongViecInfo> LinhVucCongViec { get; set; }

        public int? TrangThaiCongViecId { get; set; }
        public IEnumerable<TrangThaiCongViecInfo> TrangThaiCongViec { get; set; }

        //public EnumStatus Status { get; set; }

        public EnumRoleExecute Role { get; set; }

        public ValueSearchViewModel ValueSearch { get; set; }
    }
}