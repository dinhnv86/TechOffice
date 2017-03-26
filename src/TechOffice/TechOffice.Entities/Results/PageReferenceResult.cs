namespace AnThinhPhat.Entities.Results
{
    public class PageReferenceResult : DataResult
    {
        public string UrlImage { get; set; }

        public string UrlLink { get; set; }

        public string Alt { get; set; }

        public bool IsNewPage { get; set; }
    }
}
