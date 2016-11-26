using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;

namespace AnThinhPhat.ViewModel.Menu
{
    public class InitMenuVanBanViewModel
    {
        public IEnumerable<CoQuanBanHanhVanBanInfo> CoQuanBanHanhVanBanInfos { get; set; }

        public IEnumerable<LoaiVanBanInfo> LoaiVanBanInfos { get; set; }
    }
}