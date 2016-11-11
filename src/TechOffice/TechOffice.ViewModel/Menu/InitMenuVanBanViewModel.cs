using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.Menu
{
    public class InitMenuVanBanViewModel
    {
        public IEnumerable<LinhVucVanBanInfo> LinhVucVanBanInfos { get; set; }

        public IEnumerable<LoaiVanBanInfo> LoaiVanBanInfos { get; set; }
    }
}
