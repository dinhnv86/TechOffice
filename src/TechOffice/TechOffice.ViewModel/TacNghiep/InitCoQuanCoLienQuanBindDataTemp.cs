using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class InitCoQuanCoLienQuanBindDataTemp
    {
        public string ParentNameSpace { get; set; }

        public string ParentId { get; set; }

        public List<CoQuanInfo> CoQuanInfos { get; set; }
    }
}
