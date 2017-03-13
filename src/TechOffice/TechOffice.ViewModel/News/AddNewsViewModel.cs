using AnThinhPhat.Entities.Infos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AnThinhPhat.ViewModel.News
{
    public class AddNewsViewModel : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "News_AddNews_Title")]
        [MaxLength(1025, ErrorMessageResourceName = "News_AddNews_Title_MaxLength", ErrorMessageResourceType = typeof(Resources.Messages))]
        public string Title { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full")]
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "News_AddNews_Content")]
        public string Content { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "News_AddNews_Summary")]
        [MaxLength(1025, ErrorMessageResourceName = "News_AddNews_Title_MaxLength", ErrorMessageResourceType = typeof(Resources.Messages))]
        public string Summary { get;set;}

        public string UrlImage { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = "News_AddNews_NewCategoryId")]
        public int NewsCategoryId { get; set; }

        public IEnumerable<BaseDataViewModel> NewsCategory { get; set; }
    }
}
