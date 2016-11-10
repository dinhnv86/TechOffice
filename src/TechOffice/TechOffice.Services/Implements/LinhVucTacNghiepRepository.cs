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
    public class LinhVucTacNghiepRepository : DbExecute, ILinhVucTacNghiepRepository
    {
        public LinhVucTacNghiepRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(LinhVucTacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.LinhVucTacNghieps.Create();

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

        public async Task<SaveResult> AddAsync(LinhVucTacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.LinhVucTacNghieps.Create();

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

        public SaveResult AddRange(IEnumerable<LinhVucTacNghiepResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    LinhVucTacNghiep add;
                    foreach (var entity in entities)
                    {
                        add = context.LinhVucTacNghieps.Create();

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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<LinhVucTacNghiepResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    LinhVucTacNghiep add;
                    foreach (var entity in entities)
                    {
                        add = context.LinhVucTacNghieps.Create();

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

        public SaveResult Delete(LinhVucTacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.LinhVucTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(LinhVucTacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.LinhVucTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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
                    var cv = context.LinhVucTacNghieps.Single(x => x.Id == id && x.IsDeleted == false);

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
                    var cv = context.LinhVucTacNghieps.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<LinhVucTacNghiepResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.LinhVucTacNghieps
                            where item.IsDeleted == false
                            select item)
                            .MakeQueryToDatabase()
                            .Select(x => x.ToDataResult())
                            .ToList();
                }
            });
        }

        public async Task<IEnumerable<LinhVucTacNghiepResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.LinhVucTacNghieps
                                  where item.IsDeleted == false
                                  select item)
                                  .MakeQueryToDatabase()
                                  .Select(x => x.ToDataResult())
                                  .AsQueryable()
                                  .ToListAsync();
                }
            });
        }

        public LinhVucTacNghiepResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.LinhVucTacNghieps
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item)
                            .Select(x => x.ToDataResult())
                            .Single();
                }
            });
        }

        public async Task<LinhVucTacNghiepResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.LinhVucTacNghieps
                                  where item.IsDeleted == false &&
                                  item.Id == id
                                  select item)
                                  .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .SingleAsync();
                }
            });
        }

        public SaveResult Update(LinhVucTacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.LinhVucTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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

        public async Task<SaveResult> UpdateAsync(LinhVucTacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.LinhVucTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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