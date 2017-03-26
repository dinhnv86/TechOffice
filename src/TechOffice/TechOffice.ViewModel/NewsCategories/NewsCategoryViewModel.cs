using AnThinhPhat.Entities.Results;
using System.Collections.Generic;

namespace AnThinhPhat.ViewModel.NewsCategories
{
    public class NewsCategoryViewModel : BaseDataViewModel
    {
        public int? ParentId { get; set; }

        public int? Position { get; set; }

        public IEnumerable<NewsCategoryResult> NewsCategories { get; set; }
    }
}