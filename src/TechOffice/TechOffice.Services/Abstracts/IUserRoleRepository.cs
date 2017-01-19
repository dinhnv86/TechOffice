using System.Collections.Generic;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Results;

namespace AnThinhPhat.Services.Abstracts
{
    /// <summary>
    /// </summary>
    public interface IUserRoleRepository
    {
        /// <summary>
        ///     Gets all user by role.
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserRoleResult> GetUsersByRoleId(int roleId);

        /// <summary>
        ///     Get all role by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<UserRoleResult> GetRolesByUserId(int userId);

        /// <summary>
        ///     Get UserRole by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserRoleResult GetUserRoleById(int id);

        Task<SaveResult> LockUser(int userId);

        Task<SaveResult> UnlockUser(int userId);
    }
}