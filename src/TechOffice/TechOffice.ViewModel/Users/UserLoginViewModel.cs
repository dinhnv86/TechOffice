using System.ComponentModel.DataAnnotations;
using AnThinhPhat.Resources;

namespace AnThinhPhat.ViewModel.Users
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "Users_LoginViewModel_UserName")]
        [StringLength(150, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "Users_LoginViewModel_Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessageResourceType = typeof (Messages),
            ErrorMessageResourceName = "Users_LoginViewModel_Password_MinLength")]
        [Display(ResourceType = typeof (Labels), Name = "Users_LoginViewModel_Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}