using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class NewsCategoryResult : DataResult
    {
        public int ParentId { get; set; }

        public int Position { get; set; }

        public IEnumerable<NewsResult> News { get; set; }
    }
}
