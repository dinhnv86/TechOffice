using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel
{
    public class BaseDataViewModel : BaseViewModel
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}