using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TechOffice.Entities;
using TechOffice.Entities.Results;
using TechOffice.Services.Abstracts;
using TechOffice.Utilities;

namespace TechOffice.Services.Implements
{
    /// <summary>
    /// </summary>
    public class RolesRepository : IRolesRepository
    {
        /// <summary>
        ///     The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RolesRepository" /> class.
        /// </summary>
        /// <param name="logService"></param>
        public RolesRepository(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        ///     Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public RoleResult Single(int id)
        {
            RoleResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    result = (from item in context.Roles
                        where item.IsDeleted == false && item.Id == id
                        select new RoleResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.GhiChu,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
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
        ///     Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<RoleResult> SingleAsync(int id)
        {
            RoleResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    result = await (from item in context.Roles
                        where item.IsDeleted == false && item.Id == id
                        select new RoleResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.GhiChu,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
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

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleResult> GetAll()
        {
            IEnumerable<RoleResult> results;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = (from item in context.Roles
                        where item.IsDeleted == false
                        select new RoleResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.GhiChu,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
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
        ///     Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoleResult>> GetAllAsync()
        {
            IEnumerable<RoleResult> results;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = await (from item in context.Roles
                        where item.IsDeleted == false
                        select new RoleResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.GhiChu,
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
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Update(RoleResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var role = context.Roles.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    role.Ten = entity.Ten;
                    role.IsDeleted = entity.IsDeleted;
                    role.GhiChu = entity.MoTa;
                    role.LastUpdatedBy = entity.LastUpdatedBy;
                    role.LastUpdated = DateTime.Now;

                    context.Entry(role).State = EntityState.Modified;
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
        public async Task<SaveResult> UpdateAsync(RoleResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var role = context.Roles.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    role.Ten = entity.Ten;
                    role.IsDeleted = entity.IsDeleted;
                    role.GhiChu = entity.MoTa;
                    role.LastUpdatedBy = entity.LastUpdatedBy;
                    role.LastUpdated = DateTime.Now;

                    context.Entry(role).State = EntityState.Modified;
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
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Add(RoleResult entity)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Roles.Create();

                    add.GhiChu = entity.MoTa;
                    add.IsDeleted = false;
                    add.Ten = entity.Ten;
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
        public async Task<SaveResult> AddAsync(RoleResult entity)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Roles.Create();

                    add.GhiChu = entity.MoTa;
                    add.Ten = entity.Ten;
                    add.IsDeleted = false;
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
        public SaveResult AddRange(IEnumerable<RoleResult> entities)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    Role add;
                    foreach (var entity in entities)
                    {
                        add = context.Roles.Create();

                        add.GhiChu = entity.MoTa;
                        add.IsDeleted = false;
                        add.Ten = entity.Ten;
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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<RoleResult> entities)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    Role add;
                    foreach (var entity in entities)
                    {
                        add = context.Roles.Create();

                        add.GhiChu = entity.MoTa;
                        add.IsDeleted = false;
                        add.Ten = entity.Ten;
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

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Delete(RoleResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var role = context.Roles.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;
                    role.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry(role).State = EntityState.Modified;
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
        public async Task<SaveResult> DeleteAsync(RoleResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var role = context.Roles.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;
                    role.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry(role).State = EntityState.Modified;
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
                    var role = context.Roles.Single(x => x.Id == id && x.IsDeleted == false);
                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;

                    context.Entry(role).State = EntityState.Modified;
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
                    var role = context.Roles.Single(x => x.Id == id && x.IsDeleted == false);
                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;

                    context.Entry(role).State = EntityState.Modified;
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
    }
}