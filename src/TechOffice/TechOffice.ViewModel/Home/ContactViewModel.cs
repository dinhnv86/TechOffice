using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AnThinhPhat.ViewModel.Home
{
    public class ContactViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        public string CaptchaInputText { get; set; }
    }
}
