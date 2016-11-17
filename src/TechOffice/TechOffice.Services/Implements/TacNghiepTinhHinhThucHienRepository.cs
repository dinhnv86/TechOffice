using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.Utilities.Enums;

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
                    add.MucDoHoanThanhId = entity.MucDoHoanThanhId;
                    add.TacNghiepId = entity.TacNghiepId;
                    add.CoQuanId = entity.CoQuanId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

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
                    add.MucDoHoanThanhId = entity.MucDoHoanThanhId;
                    add.TacNghiepId = entity.TacNghiepId;
                    add.CoQuanId = entity.CoQuanId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

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
                        add.MucDoHoanThanhId = entity.MucDoHoanThanhId;
                        add.TacNghiepId = entity.TacNghiepId;
                        add.CoQuanId = entity.CoQuanId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

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
                    foreach (var entity in entities)
                    {
                        var add = context.TacNghiep_TinhHinhThucHien.Create();

                        add.ThoiGian = entity.ThoiGian;
                        add.MucDoHoanThanhId = entity.MucDoHoanThanhId;
                        add.TacNghiepId = entity.TacNghiepId;
                        add.CoQuanId = entity.CoQuanId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

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
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
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
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .ToListAsync();
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
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .Single();
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
                                  where item.IsDeleted == false && item.Id == id
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .SingleAsync();
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
                    update.MucDoHoanThanhId = entity.MucDoHoanThanhId;
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
                    var update = context.TacNghiep_TinhHinhThucHien.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.ThoiGian = entity.ThoiGian;
                    update.MucDoHoanThanhId = entity.MucDoHoanThanhId;
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

        public IEnumerable<TacNghiepTinhHinhThucHienResult> GetAllByTacNghiepId(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghiep_TinhHinhThucHien
                            where item.IsDeleted == false && item.TacNghiepId == id
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public SaveResult UpdateIncrementMucDoHoanThanh(int tacNghiepId, int coQuanId, string userName, EnumMucDoHoanThanh status)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghiep_TinhHinhThucHien.Where(x => x.TacNghiepId == tacNghiepId
                    && x.CoQuanId == coQuanId
                    && x.IsDeleted == false).FirstOrDefault();

                    if (update == null)//case not yet record data then insert 
                    {
                        update = new TacNghiep_TinhHinhThucHien
                        {
                            CoQuanId = coQuanId,
                            TacNghiepId = tacNghiepId,
                            CreatedBy = userName,
                            CreateDate = DateTime.Now,
                            IsDeleted = false,
                            MucDoHoanThanhId = (int)status,
                        };

                        context.Entry(update).State = EntityState.Added;
                    }
                    else
                    {
                        if (update.MucDoHoanThanhId <= (int)status)
                            return SaveResult.SUCCESS;

                        update.MucDoHoanThanhId = (int)status;
                        update.LastUpdatedBy = userName;
                        update.LastUpdated = DateTime.Now;

                        context.Entry(update).State = EntityState.Modified;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<TacNghiepTinhHinhThucHienResult> GetAllByListTacNghiepId(IEnumerable<int> tacNghiepId)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghiep_TinhHinhThucHien.Include(x => x.TacNghiep.LinhVucTacNghiep)
                            where item.IsDeleted == false && tacNghiepId.Contains(item.TacNghiepId)// .Contains(item.TacNghiepId)
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public SaveResult UpdateCoQuanLienQuan(int tacNghiepId, int coQuanId, string userName)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghiep_TinhHinhThucHien.Where(x => x.TacNghiepId == tacNghiepId
                    && x.CoQuanId == coQuanId
                    && x.IsDeleted == false).FirstOrDefault();

                    if (update == null)//case not yet record data then insert 
                    {
                        update = new TacNghiep_TinhHinhThucHien
                        {
                            CoQuanId = coQuanId,
                            TacNghiepId = tacNghiepId,
                            CreatedBy = userName,
                            CreateDate = DateTime.Now,
                            IsDeleted = false,
                            MucDoHoanThanhId = (int)EnumMucDoHoanThanh.CHUATHUHIEN,
                        };

                        context.Entry(update).State = EntityState.Added;
                    }
                    else
                    {
                        update.IsDeleted = !(update.IsDeleted);
                        update.LastUpdatedBy = userName;
                        update.LastUpdated = DateTime.Now;

                        context.Entry(update).State = EntityState.Modified;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult UpdateMucDoHoanThanhForTacNghiep(int id, string userName)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghiep_TinhHinhThucHien.Where(x => x.Id == id
                    && x.IsDeleted == false).Single();

                    if (update.MucDoHoanThanhId == (int)EnumMucDoHoanThanh.DANGTHUCHIEN)
                    {
                        update.MucDoHoanThanhId = (int)EnumMucDoHoanThanh.DAHOANHTHANH;
                        update.NgayHoanThanh = DateTime.Now;
                    }
                    else
                    {
                        update.MucDoHoanThanhId = (int)EnumMucDoHoanThanh.DANGTHUCHIEN;
                        update.NgayHoanThanh = null;
                    }

                    update.LastUpdatedBy = userName;
                    update.LastUpdated = DateTime.Now;


                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }
    }
}