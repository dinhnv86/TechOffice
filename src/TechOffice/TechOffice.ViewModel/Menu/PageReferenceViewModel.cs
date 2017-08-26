using AnThinhPhat.Resources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AnThinhPhat.ViewModel.Menu
{
    public class PageReferenceViewModel : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = ("PageRef_Add_Image"))]
        public HttpPostedFileBase Image { get; set; }

        public string UrlImage { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "PageRef_Add_UrlLink")]
        [MaxLength(255, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Page_Add_UrlLink_MaxLength")]
        public string UrlLink { get; set; }

        [MaxLength(255, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Page_Add_Alt_MaxLength")]
        public string Alt { get; set; }

        public bool IsNewPage { get; set; }
    }
}
