namespace AnThinhPhat.Entities.Results
{
    public class NewsResult : LogResult
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Summary { get; set; }

        public int NewsCategoryId { get; set; }

        public string UrlImage { get; set; }

        public NewsCategoryResult NewsCategory { get; set; }
    }
}
