using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class UserResult : BaseResult
    {
        public string HoVaTen { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int ChucVuId { get; set; }

        public int CoQuanId { get; set; }

        public CoQuanInfo CoQuanInfo { get; set; }

        public bool IsLocked { get; set; }

        public ChucVuInfo ChucVuInfo { get; set; }

        public IEnumerable<UserRoleInfo> UserRoles { get; set; }
    }
}