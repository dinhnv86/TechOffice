using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.Entities;

namespace AnThinhPhat.Services.Implements
{
    /// <summary>
    /// </summary>
    public class UserRoleRepository : DbExecute, IUserRoleRepository
    {
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChuVuRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public UserRoleRepository(ILogService logService)
        {
            _logService = logService;
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
                            select new UserRoleResult
                            {
                                Id = item.Id,
                                UserInfo = item.User.ToDataInfo(),
                                RoleId = item.RoleId,
                                RoleInfo = item.Role.ToDataInfo(),
                            }).ToList();
                }
            });
        }

        /// <summary>
        /// Get all role by user id
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
                            select new UserRoleResult
                            {
                                Id = item.Id,
                                UserInfo = item.User.ToDataInfo(),
                                RoleId = item.RoleId,
                                RoleInfo = item.Role.ToDataInfo(),
                            }).ToList();
                }
            });
        }

        /// <summary>
        /// Get UserRole by id
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
                            select new UserRoleResult
                            {
                                Id = item.Id,
                                UserInfo = item.User.ToDataInfo(),
                                RoleId = item.RoleId,
                                RoleInfo = item.Role.ToDataInfo(),
                            }).Single();
                }
            });
        }
    }
}