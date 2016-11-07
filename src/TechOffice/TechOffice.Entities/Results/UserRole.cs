using TechOffice.Entities.Infos;

namespace TechOffice.Entities.Results
{
    public class UserRoleResult : BaseResult
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public RoleInfo RoleInfo { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}