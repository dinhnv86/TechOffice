namespace AnThinhPhat.Entities.Results
{
    public class RoleResult : DataResult
    {
        public string Display { get; set; }

        //Property extension with purpose is add roles for user
        public bool IsChecked { get; set; }
    }
}