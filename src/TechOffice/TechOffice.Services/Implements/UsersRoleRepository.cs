using System.Collections.Generic;
using System.Linq;
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
            return ExecuteDbWithHandle(
                _logService,
                () =>
                {
                    using (var context = new TechOfficeEntities())
                    {
                        return (from item in context.UserRoles
                            where item.RoleId == roleId
                                  && item.IsDeleted == false
                            select item)
                            .Select(x => x.ToDataResult())
                            .ToList();
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
            return ExecuteDbWithHandle(
                _logService,
                () =>
                {
                    using (var context = new TechOfficeEntities())
                    {
                        return (from item in context.UserRoles
                            where item.UserId == userId
                                  && item.IsDeleted == false
                            select item)
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
            return ExecuteDbWithHandle(
                _logService,
                () =>
                {
                    using (var context = new TechOfficeEntities())
                    {
                        return (from item in context.UserRoles
                            where item.Id == id
                                  && item.IsDeleted == false
                            select item)
                            .Select(x => x.ToDataResult())
                            .Single();
                    }
                });
        }
    }
}