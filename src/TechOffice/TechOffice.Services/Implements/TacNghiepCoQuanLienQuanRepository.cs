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
    public class TacNghiepCoQuanLienQuanRepository : DbExecute, ITacNghiepCoQuanLienQuanRepository
    {
        public TacNghiepCoQuanLienQuanRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(TacNghiepCoQuanLienQuanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TacNghiep_CoQuanLienQuan.Create();

                    add.TacNghiepId = entity.TacNghiepId;
                    add.CoQuanId = entity.CoQuanId;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(TacNghiepCoQuanLienQuanResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TacNghiep_CoQuanLienQuan.Create();

                    add.TacNghiepId = entity.TacNghiepId;
                    add.CoQuanId = entity.CoQuanId;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<TacNghiepCoQuanLienQuanResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TacNghiep_CoQuanLienQuan add;
                    foreach (var entity in entities)
                    {
                        add = context.TacNghiep_CoQuanLienQuan.Create();

                        add.TacNghiepId = entity.TacNghiepId;
                        add.CoQuanId = entity.CoQuanId;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<TacNghiepCoQuanLienQuanResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TacNghiep_CoQuanLienQuan add;
                    foreach (var entity in entities)
                    {
                        add = context.TacNghiep_CoQuanLienQuan.Create();

                        add.TacNghiepId = entity.TacNghiepId;
                        add.CoQuanId = entity.CoQuanId;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(TacNghiepCoQuanLienQuanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghiep_CoQuanLienQuan.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(TacNghiepCoQuanLienQuanResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghiep_CoQuanLienQuan.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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
                    var cv = context.TacNghiep_CoQuanLienQuan.Single(x => x.Id == id && x.IsDeleted == false);

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
                    var cv = context.TacNghiep_CoQuanLienQuan.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<TacNghiepCoQuanLienQuanResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghiep_CoQuanLienQuan
                        where item.IsDeleted == false
                        select new TacNghiepCoQuanLienQuanResult
                        {
                            Id = item.Id,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
                }
            });
        }

        public async Task<IEnumerable<TacNghiepCoQuanLienQuanResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghiep_CoQuanLienQuan
                        where item.IsDeleted == false
                        select new TacNghiepCoQuanLienQuanResult
                        {
                            Id = item.Id,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToListAsync();
                }
            });
        }

        public TacNghiepCoQuanLienQuanResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghiep_CoQuanLienQuan
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new TacNghiepCoQuanLienQuanResult
                        {
                            Id = item.Id,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).Single();
                }
            });
        }

        public async Task<TacNghiepCoQuanLienQuanResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghiep_CoQuanLienQuan
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new TacNghiepCoQuanLienQuanResult
                        {
                            Id = item.Id,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).SingleAsync();
                }
            });
        }

        public SaveResult Update(TacNghiepCoQuanLienQuanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghiep_CoQuanLienQuan.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.TacNghiepId = entity.TacNghiepId;
                    update.CoQuanId = entity.CoQuanId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(TacNghiepCoQuanLienQuanResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghiep_CoQuanLienQuan.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.TacNghiepId = entity.TacNghiepId;
                    update.CoQuanId = entity.CoQuanId;
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