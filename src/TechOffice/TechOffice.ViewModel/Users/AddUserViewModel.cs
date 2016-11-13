using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.Users
{
    public class AddUserViewModel : InitUserViewModel
    {
        [DisplayName("Vai trò")]
        public IEnumerable<AddRoleInfoViewModel> RoleInfos { get; set; }
    }

    public class AddRoleInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Display { get; set; }

        public bool IsChecked { get; set; }
    }
}