using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using System.Data.Entity;

namespace AnThinhPhat.Services.Implements
{
    /// <summary>
    /// </summary>
    public class ChucVuRepository : DbExecute, IChucVuRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChucVuRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public ChucVuRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(ChucVuResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.ChucVus.Create();

                    add.Ten = entity.Ten;
                    add.MoTa = entity.MoTa;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(ChucVuResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.ChucVus.Create();

                    add.Ten = entity.Ten;
                    add.MoTa = entity.MoTa;
                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<ChucVuResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    ChucVu add;
                    foreach (var entity in entities)
                    {
                        add = context.ChucVus.Create();

                        add.Ten = entity.Ten;
                        add.MoTa = entity.MoTa;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<ChucVuResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    ChucVu add;
                    foreach (var entity in entities)
                    {
                        add = context.ChucVus.Create();

                        add.Ten = entity.Ten;
                        add.MoTa = entity.MoTa;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(ChucVuResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    chucvu.IsDeleted = true;
                    chucvu.LastUpdatedBy = entity.LastUpdatedBy;
                    chucvu.LastUpdated = DateTime.Now;

                    context.Entry(chucvu).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(ChucVuResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    chucvu.IsDeleted = true;
                    chucvu.LastUpdatedBy = entity.LastUpdatedBy;
                    chucvu.LastUpdated = DateTime.Now;

                    context.Entry(chucvu).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult DeleteBy(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == id && x.IsDeleted == false);

                    chucvu.IsDeleted = true;
                    chucvu.LastUpdated = DateTime.Now;

                    context.Entry(chucvu).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteByAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == id && x.IsDeleted == false);
                    chucvu.IsDeleted = true;

                    context.Entry(chucvu).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<ChucVuResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.ChucVus
                            where item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<ChucVuResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await
                                (from item in context.ChucVus
                                 where item.IsDeleted == false
                                 select new ChucVuResult
                                 {
                                     Id = item.Id,
                                     Ten = item.Ten,
                                     MoTa = item.MoTa,
                                     IsDeleted = item.IsDeleted,
                                     CreateDate = item.CreateDate,
                                     CreatedBy = item.CreatedBy,
                                     LastUpdatedBy = item.LastUpdatedBy,
                                     LastUpdated = item.LastUpdated
                                 }).ToListAsync();
                }
            });
        }

        public ChucVuResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.ChucVus
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item)
                            .MakeQueryToDatabase()
                            .Select(x => x.ToDataResult()).Single();
                }
            });
        }

        public async Task<ChucVuResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.ChucVus
                                  where item.IsDeleted == false &&
                                        item.Id == id
                                  select new ChucVuResult
                                  {
                                      Id = item.Id,
                                      Ten = item.Ten,
                                      MoTa = item.MoTa,
                                      IsDeleted = item.IsDeleted,
                                      CreateDate = item.CreateDate,
                                      CreatedBy = item.CreatedBy,
                                      LastUpdatedBy = item.LastUpdatedBy,
                                      LastUpdated = item.LastUpdated
                                  }).SingleAsync();
                }
            });
        }

        public SaveResult Update(ChucVuResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Ten = entity.Ten;
                    update.MoTa = entity.MoTa;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(ChucVuResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Ten = entity.Ten;
                    update.MoTa = entity.MoTa;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }
    }
}