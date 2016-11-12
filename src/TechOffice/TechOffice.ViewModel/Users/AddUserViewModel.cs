using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.Users
{
    public class AddUserViewModel : InitUserViewModel
    {
        [DisplayName("Vai trò"), Required]
        public IEnumerable<AddRoleInfoViewModel> RoleInfos { get; set; }
    }

    public class AddRoleInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}