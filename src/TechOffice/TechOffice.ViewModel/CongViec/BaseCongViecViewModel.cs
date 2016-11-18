using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class BaseCongViecViewModel
    {
        public IEnumerable<UserInfo> UsersInfos { get; set; }

        public IEnumerable<LinhVucCongViecInfo> LinhVucCongViecInfos { get; set; }

        public IEnumerable<TrangThaiCongViecInfo> TrangThaiCongViecInfos { get; set; }
    }
}
