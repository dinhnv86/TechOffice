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
    public class LinhVucCongViecRepository : DbExecute, ILinhVucCongViecRepository
    {
        public LinhVucCongViecRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(LinhVucCongViecResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.LinhVucCongViecs.Create();

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

        public async Task<SaveResult> AddAsync(LinhVucCongViecResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.LinhVucCongViecs.Create();

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

        public SaveResult AddRange(IEnumerable<LinhVucCongViecResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    LinhVucCongViec add;
                    foreach (var entity in entities)
                    {
                        add = context.LinhVucCongViecs.Create();

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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<LinhVucCongViecResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    LinhVucCongViec add;
                    foreach (var entity in entities)
                    {
                        add = context.LinhVucCongViecs.Create();

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

        public SaveResult Delete(LinhVucCongViecResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.LinhVucCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(LinhVucCongViecResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.LinhVucCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;

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
                    var cv = context.LinhVucCongViecs.Single(x => x.Id == id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;

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
                    var cv = context.LinhVucCongViecs.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<LinhVucCongViecResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.LinhVucCongViecs
                            where item.IsDeleted == false
                            select new LinhVucCongViecResult
                            {
                                Id = item.Id,
                                Ten = item.Ten,
                                MoTa = item.MoTa,
                                IsDeleted = item.IsDeleted,
                                CreateDate = item.CreateDate,
                                CreatedBy = item.CreatedBy,
                                LastUpdatedBy = item.LastUpdatedBy,
                                LastUpdated = item.LastUpdated
                            }).ToList();
                }
            });
        }

        public async Task<IEnumerable<LinhVucCongViecResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.LinhVucCongViecs
                                  where item.IsDeleted == false
                                  select new LinhVucCongViecResult
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

        public LinhVucCongViecResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.LinhVucCongViecs
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item).Select(x => x.ToDataResult()).Single();
                }
            });
        }

        public async Task<LinhVucCongViecResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.LinhVucCongViecs
                                  where item.IsDeleted == false &&
                                        item.Id == id
                                  select item)
                        .Select(x => x.ToDataResult())
                        .SingleAsync();
                }
            });
        }

        public SaveResult Update(LinhVucCongViecResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.LinhVucCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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

        public async Task<SaveResult> UpdateAsync(LinhVucCongViecResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.LinhVucCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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