using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AnThinhPhat.ViewModel.Home
{
    public class ContactViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "Home_Contact_FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "Home_Contact_Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "Home_Contact_Title")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "Home_Contact_NoiDung")]
        public string NoiDung { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "Home_Contact_MaXacNhan")]
        public string CaptchaInputText { get; set; }
    }
}
