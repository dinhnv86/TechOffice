using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.Users
{
    public  class UserLoginViewModel
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        [Display(Name = "Remember Me? ")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
