using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.Services.Implements
{
    /// <summary>
    /// </summary>
    public class UserRoleRepository : DbExecute, IUserRoleRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChucVuRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public UserRoleRepository(ILogService logService) : base(logService)
        {
        }

        /// <summary>
        ///     Gets all user by role.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserRoleResult> GetUsersByRoleId(int roleId)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.UserRoles
                            where item.RoleId == roleId
                                  && item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult()).ToList();
                }
            });
        }

        /// <summary>
        ///     Get all role by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserRoleResult> GetRolesByUserId(int userId)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.UserRoles
                            where item.UserId == userId
                                  && item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        /// <summary>
        ///     Get UserRole by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserRoleResult GetUserRoleById(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.UserRoles
                            where item.Id == id && item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .Single();
                }
            });
        }

        public async Task<SaveResult> LockUser(int userId)
        {
            return await UnlockOrLockUser(userId, true);
        }

        public async Task<SaveResult> UnlockUser(int userId)
        {
            return await UnlockOrLockUser(userId, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isLock">
        /// In the case want account user Lock  then set IsLock=true, otherwise then false
        /// </param>
        /// <returns></returns>
        private async Task<SaveResult> UnlockOrLockUser(int userId, bool isLock)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
             {
                 using (var context = new TechOfficeEntities())
                 {
                     var user = (from item in context.Users
                                 where item.Id == userId && item.IsDeleted == false
                                 select item).FirstOrDefault();

                     if (user == null)
                         return SaveResult.FAILURE;

                     user.IsLocked = isLock;

                     context.Entry(user).State = EntityState.Modified;

                     return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                 }
             });
        }
    }
}