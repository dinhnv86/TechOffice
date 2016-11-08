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
    public class TacNghiepTinhHinhThucHienRepository : DbExecute, ITacNghiepTinhHinhThucHienRepository
    {
        public TacNghiepTinhHinhThucHienRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(TacNghiepTinhHinhThucHienResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TacNghiep_TinhHinhThucHien.Create();

                    add.ThoiGian = entity.ThoiGian;
                    add.MucDoHoanThanh = entity.MucDoHoanThanh;
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

        public async Task<SaveResult> AddAsync(TacNghiepTinhHinhThucHienResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.TacNghiep_TinhHinhThucHien.Create();

                    add.ThoiGian = entity.ThoiGian;
                    add.MucDoHoanThanh = entity.MucDoHoanThanh;
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

        public SaveResult AddRange(IEnumerable<TacNghiepTinhHinhThucHienResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TacNghiep_TinhHinhThucHien add;
                    foreach (var entity in entities)
                    {
                        add = context.TacNghiep_TinhHinhThucHien.Create();

                        add.ThoiGian = entity.ThoiGian;
                        add.MucDoHoanThanh = entity.MucDoHoanThanh;
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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<TacNghiepTinhHinhThucHienResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    TacNghiep_TinhHinhThucHien add;
                    foreach (var entity in entities)
                    {
                        add = context.TacNghiep_TinhHinhThucHien.Create();

                        add.ThoiGian = entity.ThoiGian;
                        add.MucDoHoanThanh = entity.MucDoHoanThanh;
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

        public SaveResult Delete(TacNghiepTinhHinhThucHienResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghiep_TinhHinhThucHien.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(TacNghiepTinhHinhThucHienResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghiep_TinhHinhThucHien.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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
                    var cv = context.TacNghiep_TinhHinhThucHien.Single(x => x.Id == id && x.IsDeleted == false);

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
                    var cv = context.TacNghiep_TinhHinhThucHien.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<TacNghiepTinhHinhThucHienResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghiep_TinhHinhThucHien
                        where item.IsDeleted == false
                        select new TacNghiepTinhHinhThucHienResult
                        {
                            Id = item.Id,
                            ThoiGian = item.ThoiGian,
                            MucDoHoanThanh = item.MucDoHoanThanh,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
                }
            });
        }

        public async Task<IEnumerable<TacNghiepTinhHinhThucHienResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghiep_TinhHinhThucHien
                        where item.IsDeleted == false
                        select new TacNghiepTinhHinhThucHienResult
                        {
                            Id = item.Id,
                            ThoiGian = item.ThoiGian,
                            MucDoHoanThanh = item.MucDoHoanThanh,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToListAsync();
                }
            });
        }

        public TacNghiepTinhHinhThucHienResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghiep_TinhHinhThucHien
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new TacNghiepTinhHinhThucHienResult
                        {
                            Id = item.Id,
                            ThoiGian = item.ThoiGian,
                            MucDoHoanThanh = item.MucDoHoanThanh,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).Single();
                }
            });
        }

        public async Task<TacNghiepTinhHinhThucHienResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghiep_TinhHinhThucHien
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new TacNghiepTinhHinhThucHienResult
                        {
                            Id = item.Id,
                            ThoiGian = item.ThoiGian,
                            MucDoHoanThanh = item.MucDoHoanThanh,
                            TacNghiepId = item.TacNghiepId,
                            TacNghiepInfo = item.TacNghiep.ToIfNotNullDataInfo(),
                            CoQuanId = item.CoQuanId,
                            CoQuanInfo = item.CoQuan.ToIfNotNullDataInfo(),
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).SingleAsync();
                }
            });
        }

        public SaveResult Update(TacNghiepTinhHinhThucHienResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update =
                        context.TacNghiep_TinhHinhThucHien.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.ThoiGian = entity.ThoiGian;
                    update.MucDoHoanThanh = entity.MucDoHoanThanh;
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

        public async Task<SaveResult> UpdateAsync(TacNghiepTinhHinhThucHienResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update =
                        context.TacNghiep_TinhHinhThucHien.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.ThoiGian = entity.ThoiGian;
                    update.MucDoHoanThanh = entity.MucDoHoanThanh;
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