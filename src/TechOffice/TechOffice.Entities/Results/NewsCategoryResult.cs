using System.Collections.Generic;

namespace AnThinhPhat.Entities.Results
{
    public class NewsCategoryResult : DataResult
    {
        public IEnumerable<NewsResult> News { get; set; }
    }
}
