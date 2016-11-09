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
    public class RolesRepository : DbExecute, IRoleRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RolesRepository" /> class.
        /// </summary>
        /// <param name="logService"></param>
        public RolesRepository(ILogService logService) : base(logService)
        {
        }

        /// <summary>
        ///     Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public RoleResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.Roles
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
            });
        }

        /// <summary>
        ///     Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<RoleResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.Roles
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
            });
        }

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.Roles
                            where item.IsDeleted == false
                            select item)
                            .MakeQueryToDatabase()
                            .Select(x => x.ToDataResult()).ToList();
                }
            });
        }

        /// <summary>
        ///     Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoleResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.Roles
                                  where item.IsDeleted == false
                                  select new RoleResult
                                  {
                                      Id = item.Id,
                                      Ten = item.Ten,
                                      MoTa = item.GhiChu,
                                      IsDeleted = item.IsDeleted,
                                      CreateDate = item.CreateDate,
                                      CreatedBy = item.CreatedBy,
                                      LastUpdatedBy = item.LastUpdatedBy,
                                      LastUpdated = item.LastUpdated
                                  }).ToListAsync();
                }
            });
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Update(RoleResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
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
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> UpdateAsync(RoleResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
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
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Add(RoleResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Roles.Create();

                    add.GhiChu = entity.MoTa;
                    add.Ten = entity.Ten;

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
        public async Task<SaveResult> AddAsync(RoleResult entity)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.Roles.Create();

                    add.GhiChu = entity.MoTa;
                    add.Ten = entity.Ten;

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
        public SaveResult AddRange(IEnumerable<RoleResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    Role add;
                    foreach (var entity in entities)
                    {
                        add = context.Roles.Create();

                        add.GhiChu = entity.MoTa;
                        add.Ten = entity.Ten;

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
        public async Task<SaveResult> AddRangeAsync(IEnumerable<RoleResult> entities)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    Role add;
                    foreach (var entity in entities)
                    {
                        add = context.Roles.Create();

                        add.GhiChu = entity.MoTa;
                        add.Ten = entity.Ten;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public SaveResult Delete(RoleResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var role = context.Roles.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;
                    role.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry(role).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        /// <summary>
        ///     Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<SaveResult> DeleteAsync(RoleResult entity)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var role = context.Roles.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;
                    role.LastUpdatedBy = entity.LastUpdatedBy;

                    context.Entry(role).State = EntityState.Modified;
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
                    var role = context.Roles.Single(x => x.Id == id && x.IsDeleted == false);
                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;

                    context.Entry(role).State = EntityState.Modified;
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
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var role = context.Roles.Single(x => x.Id == id && x.IsDeleted == false);
                    role.IsDeleted = true;
                    role.LastUpdated = DateTime.Now;

                    context.Entry(role).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }
    }
}