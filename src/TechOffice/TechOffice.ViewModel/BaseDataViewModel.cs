using System.ComponentModel.DataAnnotations;
using AnThinhPhat.Resources;

namespace AnThinhPhat.ViewModel
{
    public class BaseDataViewModel : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof (Messages), ErrorMessageResourceName = "BaseDataViewModel_Name"),
         MaxLength(255, ErrorMessageResourceType = typeof (Messages),
             ErrorMessageResourceName = "BaseDataViewModel_Name_MaxLength")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}