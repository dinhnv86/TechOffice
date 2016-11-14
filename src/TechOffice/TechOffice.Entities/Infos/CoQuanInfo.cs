namespace AnThinhPhat.Entities.Infos
{
    public class CoQuanInfo : DataInfo
    {
        //For new add tac nghiep
        public bool IsSelected { get; set; } = false;

        public int NhomCoQuanId { get; set; }
    }
}