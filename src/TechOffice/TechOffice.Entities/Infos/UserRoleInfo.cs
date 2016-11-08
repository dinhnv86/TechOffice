namespace AnThinhPhat.Entities.Infos
{
    public class UserRoleInfo : BaseInfo
    {
        public UserInfo UserInfo { get; set; }

        public RoleInfo RoleInfo { get; set; }
    }
}