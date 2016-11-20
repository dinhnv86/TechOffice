using System;
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
    public class UsersRepository : DbExecute, IUsersRepository
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UsersRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public UsersRepository(ILogService logService) : base(logService)
        {
        }

        #endregion

        #region Implement Single

        /// <summary>
        ///     Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public UserResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.Users
                            where item.IsDeleted == false && item.Id == id
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .Single();
                }
            });
        }

        /// <summary>
        ///     Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<UserResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.Users
                                  where item.IsDeleted == false && item.Id == id
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .SingleAsync();
                }
            });
        }

        #endregion

        #region Implement Get

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.Users
                            where item.IsDeleted == false
                            orderby item.UserName
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        /// <summary>
        ///     Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.Users
                                  where item.IsDeleted == false
                                  orderby item.UserName
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .ToListAsync();
                }
            });
        }

        public IEnumerable<UserResult> GetUsersByCoQuanId(int coQuanId)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.Users
                            where item.IsDeleted == false && item.CoQuanId == coQuanId
                            orderby item.UserName
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }
        #endregion

        #region Implement Update

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Update(UserResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.IsLocked = entity.IsLocked;
                    update.HoVaTen = entity.HoVaTen;
                    update.ChucVuId = entity.ChucVuId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> UpdateAsync(UserResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.IsLocked = entity.IsLocked;
                    update.HoVaTen = entity.HoVaTen;
                    update.ChucVuId = entity.ChucVuId;

                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        #endregion

        #region Implement Add

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Add(UserResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Users.Create();

                    add.UserName = entity.UserName;
                    add.Password = AppCipher.EncryptCipher(entity.Password);
                    add.IsLocked = entity.IsLocked;
                    add.HoVaTen = entity.HoVaTen;
                    add.ChucVuId = entity.ChucVuId;
                    add.CoQuanId = entity.CoQuanId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddAsync(UserResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Users.Create();

                    add.UserName = entity.UserName;
                    add.Password = AppCipher.EncryptCipher(entity.Password);

                    add.IsLocked = entity.IsLocked;
                    add.HoVaTen = entity.HoVaTen;
                    add.ChucVuId = entity.ChucVuId;
                    add.CoQuanId = entity.CoQuanId;
                    add.HoVaTen = entity.HoVaTen;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public SaveResult AddRange(IEnumerable<UserResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    User add;
                    foreach (var entity in entities)
                    {
                        add = context.Users.Create();

                        add.UserName = entity.UserName;
                        add.Password = AppCipher.EncryptCipher(entity.Password);
                        add.IsLocked = entity.IsLocked;
                        add.HoVaTen = entity.HoVaTen;
                        add.ChucVuId = entity.ChucVuId;
                        add.CoQuanId = entity.CoQuanId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddRangeAsync(IEnumerable<UserResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    User add;
                    foreach (var entity in entities)
                    {
                        add = context.Users.Create();

                        add.UserName = entity.UserName;
                        add.Password = AppCipher.EncryptCipher(entity.Password);
                        add.IsLocked = entity.IsLocked;
                        add.HoVaTen = entity.HoVaTen;
                        add.ChucVuId = entity.ChucVuId;
                        add.CoQuanId = entity.CoQuanId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddUserWithRoles(UserResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                var result = SaveResult.FAILURE;

                using (var context = new TechOfficeEntities())
                {
                    using (var transaction = context.BeginTransaction())
                    {
                        var add = context.Users.Create();

                        add.UserName = entity.UserName;
                        add.Password = AppCipher.EncryptCipher(entity.Password);
                        add.IsLocked = entity.IsLocked;
                        add.HoVaTen = entity.HoVaTen;
                        add.ChucVuId = entity.ChucVuId;
                        add.CoQuanId = entity.CoQuanId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;

                        UserRole role;
                        foreach (var item in entity.UserRoles)
                        {
                            role = context.UserRoles.Create();

                            role.RoleId = item.RoleInfo.Id;
                            role.UserId = add.Id;

                            role.IsDeleted = entity.IsDeleted;
                            role.CreatedBy = add.CreatedBy;
                            role.CreateDate = add.CreateDate;

                            context.Entry(role).State = EntityState.Added;
                        }

                        result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                        transaction.Commit();
                    }
                }
                return result;
            });
        }

        public SaveResult EditUserWtithRoles(UserResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                var result = SaveResult.FAILURE;

                using (var context = new TechOfficeEntities())
                {
                    using (var transaction = context.BeginTransaction())
                    {
                        var update = context.Users.Where(x => x.Id == entity.Id).Single();

                        update.UserName = entity.UserName;
                        update.IsLocked = entity.IsLocked;
                        update.HoVaTen = entity.HoVaTen;
                        update.ChucVuId = entity.ChucVuId;
                        update.CoQuanId = entity.CoQuanId;

                        update.IsDeleted = entity.IsDeleted;
                        update.LastUpdatedBy = entity.LastUpdatedBy;
                        update.LastUpdated = DateTime.Now;

                        context.Entry(update).State = EntityState.Modified;

                        //Remove all roles of user
                        RemoveAllRolesOfUser(context, entity.Id);

                        UserRole role;
                        foreach (var item in entity.UserRoles)
                        {
                            role = context.UserRoles.Create();
                            role.RoleId = item.RoleInfo.Id;
                            role.UserId = update.Id;

                            role.IsDeleted = entity.IsDeleted;
                            role.CreatedBy = update.CreatedBy;
                            role.CreateDate = update.CreateDate;

                            context.Entry(role).State = EntityState.Added;
                        }

                        result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                        transaction.Commit();
                    }
                }
                return result;
            });
        }
        #endregion

        #region Implement Delete

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Delete(UserResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteAsync(UserResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Deletes the by.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult DeleteBy(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Deletes the by asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteByAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        #endregion

        #region Implement Login

        /// <summary>
        ///     Logins the specified userName.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public UserResult Login(string userName, string password)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var passHash = AppCipher.EncryptCipher(password);
                    return (from item in context.Users
                            where item.UserName == userName &&
                                  item.Password == passHash
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .Single();
                }
            });
        }

        /// <summary>
        ///     Logins the asynchronous.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<UserResult> LoginAsync(string userName, string password)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var passHash = AppCipher.EncryptCipher(password);
                    return await (from item in context.Users
                                  where item.UserName == userName &&
                                        item.Password == passHash
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .SingleAsync();
                }
            });
        }

        #endregion

        #region Implement Unlock and Lock

        /// <summary>
        ///     Unlockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult Unlocked(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = false;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Lockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult Locked(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = true;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Unlockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> UnlockedAsync(int id)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = false;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Lockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> LockedAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = true;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Gets all unlocked.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResult> FindAllUnlocked()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.Users
                            where item.IsDeleted == false && item.IsLocked == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult());
                }
            });
        }

        /// <summary>
        ///     Gets all unlocked asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResult>> FindAllUnlockedAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.Users
                                  where item.IsDeleted == false && item.IsLocked == false
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .ToListAsync();
                }
            });
        }

        /// <summary>
        ///     Gets all locked.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResult> FindAllLocked()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.Users
                            where item.IsDeleted == false && item.IsLocked
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult());
                }
            });
        }

        /// <summary>
        ///     Gets all locked asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResult>> FindAllLockedAsync()
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.Users
                                  where item.IsDeleted == false && item.IsLocked
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .ToListAsync();
                }
            });
        }

        #endregion

        #region Implement Check userName available

        /// <summary>
        ///     Checks the exist userName.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        public UserResult CheckUserName(string userName)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var user = context.Users.SingleOrDefault(x => x.UserName == userName);

                    return user.ToIfNotNullDataResult();
                }
            });
        }

        /// <summary>
        ///     Checks the exist userName asynchronous.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        public async Task<UserResult> CheckUserNameAsync(string userName)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var user = await context.Users.SingleOrDefaultAsync(x => x.UserName == userName);
                    return user.ToIfNotNullDataResult();
                }
            });
        }

        #endregion

        #region Implement Reset password

        /// <summary>
        ///     Resets the password.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public SaveResult ResetPassword(int id, string newPassword)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    update.Password = AppCipher.EncryptCipher(newPassword);

                    context.Entry(update).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Resets the password asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public async Task<SaveResult> ResetPasswordAsync(int id, string newPassword)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    update.Password = AppCipher.EncryptCipher(newPassword);

                    context.Entry(update).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        #endregion

        private void RemoveAllRolesOfUser(TechOfficeEntities context, int userId)
        {
            context.UserRoles.Where(x => x.UserId == userId).ToList().ForEach(x =>
            {
                context.Entry<UserRole>(x).State = EntityState.Deleted;
            });
        }
    }
}