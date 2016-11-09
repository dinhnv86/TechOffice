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
    public class TapTinTacNghiepRepository : DbExecute, ITapTinTacNghiepRepository
    {
        public TapTinTacNghiepRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(TapTinTacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TapTinTacNghieps.Create();

                    add.Url = entity.Url;
                    add.UserUploadId = entity.UserUploadId;
                    add.TacNghiepId = entity.TacNghiepId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(TapTinTacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TapTinTacNghieps.Create();

                    add.Url = entity.Url;
                    add.UserUploadId = entity.UserUploadId;
                    add.TacNghiepId = entity.TacNghiepId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<TapTinTacNghiepResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TapTinTacNghiep add;
                    foreach (var entity in entities)
                    {
                        add = context.TapTinTacNghieps.Create();

                        add.Url = entity.Url;
                        add.UserUploadId = entity.UserUploadId;
                        add.TacNghiepId = entity.TacNghiepId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<TapTinTacNghiepResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TapTinTacNghiep add;
                    foreach (var entity in entities)
                    {
                        add = context.TapTinTacNghieps.Create();

                        add.Url = entity.Url;
                        add.UserUploadId = entity.UserUploadId;
                        add.TacNghiepId = entity.TacNghiepId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(TapTinTacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TapTinTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(TapTinTacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TapTinTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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
                    var cv = context.TapTinTacNghieps.Single(x => x.Id == id && x.IsDeleted == false);

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
                    var cv = context.TapTinTacNghieps.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<TapTinTacNghiepResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TapTinTacNghieps
                        where item.IsDeleted == false
                        select item).Select(x => x.ToDataResult()).ToList();
                }
            });
        }

        public async Task<IEnumerable<TapTinTacNghiepResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TapTinTacNghieps
                        where item.IsDeleted == false
                        select item).Select(x => x.ToDataResult()).ToListAsync();
                }
            });
        }

        public TapTinTacNghiepResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TapTinTacNghieps
                        where item.IsDeleted == false &&
                              item.Id == id
                        select item).Select(x => x.ToDataResult()).Single();
                }
            });
        }

        public async Task<TapTinTacNghiepResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TapTinTacNghieps
                        where item.IsDeleted == false &&
                              item.Id == id
                        select item).Select(x => x.ToDataResult()).SingleAsync();
                }
            });
        }

        public SaveResult Update(TapTinTacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TapTinTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Url = entity.Url;
                    update.UserUploadId = entity.UserUploadId;
                    update.TacNghiepId = entity.TacNghiepId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(TapTinTacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TapTinTacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Url = entity.Url;
                    update.UserUploadId = entity.UserUploadId;
                    update.TacNghiepId = entity.TacNghiepId;
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