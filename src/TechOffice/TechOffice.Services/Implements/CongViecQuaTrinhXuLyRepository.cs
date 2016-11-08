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
    public class CongViecQuaTrinhXuLyRepository : DbExecute, ICongViecQuaTrinhXuLyRepository
    {
        public CongViecQuaTrinhXuLyRepository(ILogService logService) : base(logService)
        {
        }


        public SaveResult Add(CongViecQuaTrinhXuLyResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.CongViec_QuaTrinhXuLy.Create();

                    add.HoSoCongViecId = entity.HoSoCongViecId;
                    add.GioBanHanh = entity.GioBanHanh;
                    add.PhutBanHanh = entity.PhutBanHanh;
                    add.NgayBanHanh = entity.NgayBanHanh;
                    add.NguoiThem = entity.NguoiThem;
                    add.NhacNho = entity.NhacNho;
                    add.NoiDung = entity.NoiDung;
                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(CongViecQuaTrinhXuLyResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.CongViec_QuaTrinhXuLy.Create();

                    add.HoSoCongViecId = entity.HoSoCongViecId;
                    add.GioBanHanh = entity.GioBanHanh;
                    add.PhutBanHanh = entity.PhutBanHanh;
                    add.NgayBanHanh = entity.NgayBanHanh;
                    add.NguoiThem = entity.NguoiThem;
                    add.NhacNho = entity.NhacNho;
                    add.NoiDung = entity.NoiDung;
                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<CongViecQuaTrinhXuLyResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    CongViec_QuaTrinhXuLy add;
                    foreach (var entity in entities)
                    {
                        add = context.CongViec_QuaTrinhXuLy.Create();
                        add.HoSoCongViecId = entity.HoSoCongViecId;
                        add.GioBanHanh = entity.GioBanHanh;
                        add.PhutBanHanh = entity.PhutBanHanh;
                        add.NgayBanHanh = entity.NgayBanHanh;
                        add.NguoiThem = entity.NguoiThem;
                        add.NhacNho = entity.NhacNho;
                        add.NoiDung = entity.NoiDung;
                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<CongViecQuaTrinhXuLyResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    CongViec_QuaTrinhXuLy add;
                    foreach (var entity in entities)
                    {
                        add = context.CongViec_QuaTrinhXuLy.Create();
                        add.HoSoCongViecId = entity.HoSoCongViecId;
                        add.GioBanHanh = entity.GioBanHanh;
                        add.PhutBanHanh = entity.PhutBanHanh;
                        add.NgayBanHanh = entity.NgayBanHanh;
                        add.NguoiThem = entity.NguoiThem;
                        add.NhacNho = entity.NhacNho;
                        add.NoiDung = entity.NoiDung;
                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(CongViecQuaTrinhXuLyResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.CongViec_QuaTrinhXuLy.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(CongViecQuaTrinhXuLyResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.CongViec_QuaTrinhXuLy.Single(x => x.Id == entity.Id && x.IsDeleted == false);
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
                    var cv = context.CongViec_QuaTrinhXuLy.Single(x => x.Id == id && x.IsDeleted == false);
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
                    var cv = context.CongViec_QuaTrinhXuLy.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<CongViecQuaTrinhXuLyResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.CongViec_QuaTrinhXuLy
                        where item.IsDeleted == false
                        select new CongViecQuaTrinhXuLyResult
                        {
                            Id = item.Id,
                            HoSoCongViecId = item.HoSoCongViecId,
                            HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                            GioBanHanh = item.GioBanHanh,
                            PhutBanHanh = item.PhutBanHanh,
                            NgayBanHanh = item.NgayBanHanh,
                            NguoiThem = item.NguoiThem,
                            NhacNho = item.NhacNho,
                            NoiDung = item.NoiDung,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
                }
            });
        }

        public async Task<IEnumerable<CongViecQuaTrinhXuLyResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.CongViec_QuaTrinhXuLy
                        where item.IsDeleted == false
                        select new CongViecQuaTrinhXuLyResult
                        {
                            Id = item.Id,
                            HoSoCongViecId = item.HoSoCongViecId,
                            HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                            GioBanHanh = item.GioBanHanh,
                            PhutBanHanh = item.PhutBanHanh,
                            NgayBanHanh = item.NgayBanHanh,
                            NguoiThem = item.NguoiThem,
                            NhacNho = item.NhacNho,
                            NoiDung = item.NoiDung,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToListAsync();
                }
            });
        }

        public CongViecQuaTrinhXuLyResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.CongViec_QuaTrinhXuLy
                        where item.IsDeleted == false && item.Id == id
                        select new CongViecQuaTrinhXuLyResult
                        {
                            Id = item.Id,
                            HoSoCongViecId = item.HoSoCongViecId,
                            HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                            GioBanHanh = item.GioBanHanh,
                            PhutBanHanh = item.PhutBanHanh,
                            NgayBanHanh = item.NgayBanHanh,
                            NguoiThem = item.NguoiThem,
                            NhacNho = item.NhacNho,
                            NoiDung = item.NoiDung,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).Single();
                }
            });
        }

        public async Task<CongViecQuaTrinhXuLyResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.CongViec_QuaTrinhXuLy
                        where item.IsDeleted == false && item.Id == id
                        select new CongViecQuaTrinhXuLyResult
                        {
                            Id = item.Id,
                            HoSoCongViecId = item.HoSoCongViecId,
                            HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                            GioBanHanh = item.GioBanHanh,
                            PhutBanHanh = item.PhutBanHanh,
                            NgayBanHanh = item.NgayBanHanh,
                            NguoiThem = item.NguoiThem,
                            NhacNho = item.NhacNho,
                            NoiDung = item.NoiDung,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).SingleAsync();
                }
            });
        }

        public SaveResult Update(CongViecQuaTrinhXuLyResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.CongViec_QuaTrinhXuLy
                        .Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.GioBanHanh = entity.GioBanHanh;
                    update.PhutBanHanh = entity.PhutBanHanh;
                    update.NgayBanHanh = entity.NgayBanHanh;
                    update.NguoiThem = entity.NguoiThem;
                    update.NhacNho = entity.NhacNho;
                    update.NoiDung = entity.NoiDung;
                    update.HoSoCongViecId = entity.HoSoCongViecId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(CongViecQuaTrinhXuLyResult entity)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.CongViec_QuaTrinhXuLy
                        .Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.GioBanHanh = entity.GioBanHanh;
                    update.PhutBanHanh = entity.PhutBanHanh;
                    update.NgayBanHanh = entity.NgayBanHanh;
                    update.NguoiThem = entity.NguoiThem;
                    update.NhacNho = entity.NhacNho;
                    update.NoiDung = entity.NoiDung;
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