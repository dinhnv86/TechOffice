﻿using System;
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
    public class CongViecVanBanRepository : DbExecute, ICongViecVanBanRepository
    {
        public CongViecVanBanRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(CongViecVanBanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.CongViec_VanBan.Create();

                    add.HoSoCongViecId = entity.HoSoCongViecId;
                    add.NgayBanHanh = entity.NgayBanHanh;
                    add.NoiDung = entity.NoiDung;
                    add.SoVanBan = entity.SoVanBan;
                    add.CoQuanId = entity.CoQuanId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(CongViecVanBanResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.CongViec_VanBan.Create();

                    add.HoSoCongViecId = entity.HoSoCongViecId;
                    add.NgayBanHanh = entity.NgayBanHanh;
                    add.NoiDung = entity.NoiDung;
                    add.SoVanBan = entity.SoVanBan;
                    add.CoQuanId = entity.CoQuanId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<CongViecVanBanResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.CongViec_VanBan.Create();

                        add.HoSoCongViecId = entity.HoSoCongViecId;
                        add.NgayBanHanh = entity.NgayBanHanh;
                        add.NoiDung = entity.NoiDung;
                        add.SoVanBan = entity.SoVanBan;
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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<CongViecVanBanResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.CongViec_VanBan.Create();

                        add.HoSoCongViecId = entity.HoSoCongViecId;
                        add.NgayBanHanh = entity.NgayBanHanh;
                        add.NoiDung = entity.NoiDung;
                        add.SoVanBan = entity.SoVanBan;
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

        public SaveResult UpdateRange(IEnumerable<CongViecVanBanResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var update = context.CongViec_VanBan
                          .Single(x => x.Id == entity.Id && x.IsDeleted == false);

                        update.SoVanBan = entity.SoVanBan;
                        update.CoQuanId = entity.CoQuanId;
                        update.NoiDung = entity.NoiDung;
                        update.NgayBanHanh = entity.NgayBanHanh;
                        update.HoSoCongViecId = entity.HoSoCongViecId;
                        update.IsDeleted = entity.IsDeleted;
                        update.LastUpdatedBy = entity.LastUpdatedBy;
                        update.LastUpdated = DateTime.Now;

                        context.Entry(update).State = EntityState.Modified;
                    }
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(CongViecVanBanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.CongViec_VanBan.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(CongViecVanBanResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.CongViec_VanBan.Single(x => x.Id == entity.Id && x.IsDeleted == false);
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
                    var cv = context.CongViec_VanBan.Single(x => x.Id == id && x.IsDeleted == false);
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
                    var cv = context.CongViec_VanBan.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<CongViecVanBanResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.CongViec_VanBan
                            where item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<CongViecVanBanResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.CongViec_VanBan
                                  where item.IsDeleted == false
                                  select item)
                                  .MakeQueryToDatabase()
                                  .Select(x => x.ToDataResult())
                                  .AsQueryable()
                                  .ToListAsync();
                }
            });
        }

        public CongViecVanBanResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.CongViec_VanBan
                            where item.IsDeleted == false && item.Id == id
                            select item)
                            .MakeQueryToDatabase()
                            .Select(x => x.ToDataResult())
                            .Single();
                }
            });
        }

        public async Task<CongViecVanBanResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.CongViec_VanBan
                                  where item.IsDeleted == false && item.Id == id
                                  select item)
                                  .MakeQueryToDatabase()
                                  .Select(x => x.ToDataResult())
                                  .AsQueryable()
                                  .SingleAsync();
                }
            });
        }

        public SaveResult Update(CongViecVanBanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.CongViec_VanBan
                        .Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.SoVanBan = entity.SoVanBan;
                    update.CoQuanId = entity.CoQuanId;
                    update.NoiDung = entity.NoiDung;
                    update.NgayBanHanh = entity.NgayBanHanh;
                    update.HoSoCongViecId = entity.HoSoCongViecId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(CongViecVanBanResult entity)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.CongViec_VanBan
                        .Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.SoVanBan = entity.SoVanBan;
                    update.CoQuanId = entity.CoQuanId;
                    update.NoiDung = entity.NoiDung;
                    update.NgayBanHanh = entity.NgayBanHanh;
                    update.HoSoCongViecId = entity.HoSoCongViecId;
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