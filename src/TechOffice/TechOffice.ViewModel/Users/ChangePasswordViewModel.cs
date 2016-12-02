using System.ComponentModel.DataAnnotations;
using AnThinhPhat.Resources;

namespace AnThinhPhat.ViewModel.Users
{
    public class ChangePasswordViewModel
    {
        [Display(ResourceType = typeof(Labels), Name = "User_ChangePassword_UserName")]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "User_ChangePassword_CurrentPassword")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        public string PasswordCurrent { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "User_ChangePassword_NewPassword")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessageResourceName = "User_ChangePassword_Length", ErrorMessageResourceType = typeof(Messages), MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Display(ResourceType = typeof(Labels), Name = "User_ChangePassword_NewConfirmPassword")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "User_ChangePassword_ConfirmNewPassword")]
        public string NewConfirmPassword { get; set; }
    }
}