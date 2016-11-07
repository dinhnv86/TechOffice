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
    public class UsersRepository : IUsersRepository
    {
        #region Constructor

        /// <summary>
        ///     The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UsersRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public UsersRepository(ILogService logService)
        {
            _logService = logService;
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
            UserResult result = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    result = (from item in context.Users
                              where item.IsDeleted == false && item.Id == id
                              select new UserResult
                              {
                                  Id = item.Id,
                                  UserName = item.UserName,
                                  IsLocked = item.IsLocked,
                                  HoVaTen = item.HoVaTen,
                                  ChucVuInfo = item.ChucVu.ToIfNotNullDataInfo(),
                                  IsDeleted = item.IsDeleted,
                                  LastUpdatedBy = item.LastUpdatedBy,
                                  LastUpdated = item.LastUpdated
                              }).Single();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        ///     Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<UserResult> SingleAsync(int id)
        {
            UserResult result = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    result = await (from item in context.Users
                                    where item.IsDeleted == false && item.Id == id
                                    select new UserResult
                                    {
                                        Id = item.Id,
                                        UserName = item.UserName,
                                        IsLocked = item.IsLocked,
                                        HoVaTen = item.HoVaTen,
                                        ChucVuInfo = item.ChucVu.ToIfNotNullDataInfo(),
                                        IsDeleted = item.IsDeleted,
                                        LastUpdatedBy = item.LastUpdatedBy,
                                        LastUpdated = item.LastUpdated
                                    }).SingleAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        #endregion

        #region Implement Get

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResult> GetAll()
        {
            IEnumerable<UserResult> results = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = (from item in context.Users
                               where item.IsDeleted == false
                               orderby item.UserName
                               select new UserResult
                               {
                                   Id = item.Id,
                                   UserName = item.UserName,
                                   IsLocked = item.IsLocked,
                                   HoVaTen = item.HoVaTen,
                                   ChucVuInfo = item.ChucVu.ToIfNotNullDataInfo(),
                                   IsDeleted = item.IsDeleted,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdated = item.LastUpdated
                               }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        /// <summary>
        ///     Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResult>> GetAllAsync()
        {
            IEnumerable<UserResult> results = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = await (from item in context.Users
                                     where item.IsDeleted == false
                                     orderby item.UserName
                                     select new UserResult
                                     {
                                         Id = item.Id,
                                         UserName = item.UserName,
                                         IsLocked = item.IsLocked,
                                         HoVaTen = item.HoVaTen,
                                         ChucVuInfo = item.ChucVu.ToIfNotNullDataInfo(),
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdated = item.LastUpdated
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return results;
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
            SaveResult result;

            try
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
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> UpdateAsync(UserResult entity)
        {
            SaveResult result;

            try
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
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
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
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Users.Create();

                    add.UserName = entity.UserName;
                    add.Password = AppCipher.EncryptCipher(entity.Password);
                    add.IsLocked = entity.IsLocked;
                    add.HoVaTen = entity.HoVaTen;
                    add.ChucVuId = entity.ChucVuId;
                    add.HoVaTen = entity.HoVaTen;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        ///     Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddAsync(UserResult entity)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Users.Create();

                    add.UserName = entity.UserName;
                    add.Password = AppCipher.EncryptCipher(entity.Password);

                    add.IsLocked = entity.IsLocked;
                    add.HoVaTen = entity.HoVaTen;
                    add.ChucVuId = entity.ChucVuId;
                    add.HoVaTen = entity.HoVaTen;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        ///     Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public SaveResult AddRange(IEnumerable<UserResult> entities)
        {
            SaveResult result;
            try
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


                        add.HoVaTen = entity.HoVaTen;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        /// <summary>
        ///     Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public async Task<SaveResult> AddRangeAsync(IEnumerable<UserResult> entities)
        {
            SaveResult result;
            try
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


                        add.HoVaTen = entity.HoVaTen;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
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
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteAsync(UserResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Deletes the by.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult DeleteBy(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Deletes the by asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteByAsync(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);
                    assembly.IsDeleted = true;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
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
            UserResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var passHash = AppCipher.EncryptCipher(password);
                    result = (from item in context.Users
                              where item.UserName == userName &&
                                    item.Password == passHash
                              select new UserResult
                              {
                                  Id = item.Id,
                                  UserName = item.UserName,
                                  HoVaTen = item.HoVaTen,
                                  ChucVuInfo = item.ChucVu.ToIfNotNullDataInfo()
                              }).Single();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = null;
            }
            return result;
        }

        /// <summary>
        ///     Logins the asynchronous.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<UserResult> LoginAsync(string userName, string password)
        {
            UserResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var passHash = AppCipher.EncryptCipher(password);
                    result = await (from item in context.Users
                                    where item.UserName == userName &&
                                          item.Password == passHash
                                    select new UserResult
                                    {
                                        Id = item.Id,
                                        UserName = item.UserName,
                                        HoVaTen = item.HoVaTen,
                                        ChucVuInfo = item.ChucVu.ToIfNotNullDataInfo()
                                    }).SingleAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = null;
            }

            return result;
        }

        #endregion

        #region Implmenet Unlock and Lock

        /// <summary>
        ///     Unlockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult Unlocked(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = false;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Lockeds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SaveResult Locked(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = true;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Unlockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> UnlockedAsync(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = false;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Lockeds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<SaveResult> LockedAsync(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var assembly = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    assembly.IsLocked = true;
                    assembly.LastUpdated = DateTime.Now;

                    context.Entry(assembly).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Gets all unlocked.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResult> FindAllUnlocked()
        {
            IEnumerable<UserResult> results;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = (from item in context.Users
                               where item.IsDeleted == false && item.IsLocked == false
                               select new UserResult
                               {
                                   Id = item.Id,
                                   UserName = item.UserName,
                                   IsLocked = item.IsLocked,
                                   HoVaTen = item.HoVaTen,
                                   IsDeleted = item.IsDeleted,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdated = item.LastUpdated
                               });
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        ///     Gets all unlocked asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResult>> FindAllUnlockedAsync()
        {
            IEnumerable<UserResult> results;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = await (from item in context.Users
                                     where item.IsDeleted == false && item.IsLocked == false
                                     select new UserResult
                                     {
                                         Id = item.Id,
                                         UserName = item.UserName,
                                         IsLocked = item.IsLocked,
                                         HoVaTen = item.HoVaTen,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdated = item.LastUpdated
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        ///     Gets all locked.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserResult> FindAllLocked()
        {
            IEnumerable<UserResult> results;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = (from item in context.Users
                               where item.IsDeleted == false && item.IsLocked
                               select new UserResult
                               {
                                   Id = item.Id,
                                   UserName = item.UserName,
                                   IsLocked = item.IsLocked,
                                   HoVaTen = item.HoVaTen,
                                   IsDeleted = item.IsDeleted,
                                   LastUpdatedBy = item.LastUpdatedBy,
                                   LastUpdated = item.LastUpdated
                               });
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
        }

        /// <summary>
        ///     Gets all locked asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResult>> FindAllLockedAsync()
        {
            IEnumerable<UserResult> results;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = await (from item in context.Users
                                     where item.IsDeleted == false && item.IsLocked
                                     select new UserResult
                                     {
                                         Id = item.Id,
                                         UserName = item.UserName,
                                         IsLocked = item.IsLocked,
                                         HoVaTen = item.HoVaTen,
                                         IsDeleted = item.IsDeleted,
                                         LastUpdatedBy = item.LastUpdatedBy,
                                         LastUpdated = item.LastUpdated
                                     }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                results = null;
            }
            return results;
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
            UserResult exist = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var user = context.Users.SingleOrDefault(x => x.UserName == userName);
                    if (user != null)
                        exist = new UserResult
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            IsLocked = user.IsLocked,
                            HoVaTen = user.HoVaTen,
                            ChucVuInfo = user.ChucVu.ToIfNotNullDataInfo(),
                            IsDeleted = user.IsDeleted,
                            LastUpdatedBy = user.LastUpdatedBy,
                            LastUpdated = user.LastUpdated
                        };
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                exist = null;
            }
            return exist;
        }

        /// <summary>
        ///     Checks the exist userName asynchronous.
        /// </summary>
        /// <param name="userName">The userName.</param>
        /// <returns></returns>
        public async Task<UserResult> CheckUserNameAsync(string userName)
        {
            UserResult exist = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var user = await context.Users.SingleOrDefaultAsync(x => x.UserName == userName);
                    if (user != null)
                        exist = new UserResult
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            IsLocked = user.IsLocked,
                            HoVaTen = user.HoVaTen,
                            ChucVuInfo = user.ChucVu.ToIfNotNullDataInfo(),
                            IsDeleted = user.IsDeleted,
                            LastUpdatedBy = user.LastUpdatedBy,
                            LastUpdated = user.LastUpdated
                        };
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                exist = null;
            }
            return exist;
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
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    update.Password = AppCipher.EncryptCipher(newPassword);

                    context.Entry(update).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        /// <summary>
        ///     Resets the password asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public async Task<SaveResult> ResetPasswordAsync(int id, string newPassword)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.Users.Single(x => x.Id == id && x.IsDeleted == false);

                    update.Password = AppCipher.EncryptCipher(newPassword);

                    context.Entry(update).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        #endregion
    }
}