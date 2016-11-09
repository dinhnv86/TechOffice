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
    public class MucDoHoanThanhRepository : DbExecute, IMucDoHoanThanhRepository
    {
        public MucDoHoanThanhRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(MucDoHoanThanhResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.MucDoHoanThanhs.Create();

                    add.Ten = entity.Ten;
                    add.MoTa = entity.MoTa;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(MucDoHoanThanhResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.MucDoHoanThanhs.Create();

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

        public SaveResult AddRange(IEnumerable<MucDoHoanThanhResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    MucDoHoanThanh add;
                    foreach (var entity in entities)
                    {
                        add = context.MucDoHoanThanhs.Create();

                        add.Ten = entity.Ten;
                        add.MoTa = entity.MoTa;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<MucDoHoanThanhResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    MucDoHoanThanh add;
                    foreach (var entity in entities)
                    {
                        add = context.MucDoHoanThanhs.Create();

                        add.Ten = entity.Ten;
                        add.MoTa = entity.MoTa;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(MucDoHoanThanhResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var ht = context.MucDoHoanThanhs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    ht.IsDeleted = true;
                    ht.LastUpdatedBy = entity.LastUpdatedBy;
                    ht.LastUpdated = DateTime.Now;

                    context.Entry(ht).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(MucDoHoanThanhResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var ht = context.MucDoHoanThanhs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    ht.IsDeleted = true;
                    ht.LastUpdatedBy = entity.LastUpdatedBy;
                    ht.LastUpdated = DateTime.Now;

                    context.Entry(ht).State = EntityState.Modified;

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
                    var ht = context.MucDoHoanThanhs.Single(x => x.Id == id && x.IsDeleted == false);

                    ht.IsDeleted = true;
                    ht.LastUpdated = DateTime.Now;

                    context.Entry(ht).State = EntityState.Modified;

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
                    var ht = context.MucDoHoanThanhs.Single(x => x.Id == id && x.IsDeleted == false);
                    ht.IsDeleted = true;

                    context.Entry(ht).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<MucDoHoanThanhResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.MucDoHoanThanhs
                        where item.IsDeleted == false
                        select new MucDoHoanThanhResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
                }
            });
        }

        public async Task<IEnumerable<MucDoHoanThanhResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.MucDoHoanThanhs
                        where item.IsDeleted == false
                        select new MucDoHoanThanhResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToListAsync();
                }
            });
        }

        public MucDoHoanThanhResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.MucDoHoanThanhs
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new MucDoHoanThanhResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).Single();
                }
            });
        }

        public async Task<MucDoHoanThanhResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.MucDoHoanThanhs
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new MucDoHoanThanhResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).SingleAsync();
                }
            });
        }

        public SaveResult Update(MucDoHoanThanhResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.MucDoHoanThanhs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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

        public async Task<SaveResult> UpdateAsync(MucDoHoanThanhResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.MucDoHoanThanhs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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