using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.Users
{
    public class InitUserViewModel : BaseViewModel
    {
        [DisplayName("Họ và tên"),Required]
        public string FullName { get; set; }

        [DisplayName("Tài khoản"), Required]
        public string UserName { get; set; }

        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [DisplayName("Chức vụ")]
        public int ChucVuId { get; set; }

        public bool IsLocked { get; set; }

        public ChucVuInfo ChucVuInfo { get; set; }

        public IEnumerable<ChucVuInfo> ChucVuInfos { get; set; }
    }
}
