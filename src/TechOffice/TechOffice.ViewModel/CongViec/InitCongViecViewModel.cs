using System.Collections.Generic;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitCongViecViewModel : BaseCongViecViewModel
    {
        public int? UserId { get; set; }

        public IEnumerable<CongViecQuaTrinhXuLyResult> QuaTrinhXyLy { get; set; }

        public int? LinhVucCongViecId { get; set; }

        public int? TrangThaiCongViecId { get; set; }

        public EnumRoleExecute Role { get; set; }

        public string NoiDungCongViec { get; set; }

        public ValueSearchViewModel ValueSearch { get; set; }
    }
}