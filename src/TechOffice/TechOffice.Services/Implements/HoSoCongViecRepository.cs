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
    public class HoSoCongViecRepository : DbExecute, IHoSoCongViecRepository
    {
        public HoSoCongViecRepository(LogService logService) : base(logService)
        {
        }

        public SaveResult Add(HoSoCongViecResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.HoSoCongViecs.Create();

                    add.NgayHetHan = entity.NgayHetHan;
                    add.UserPhuTrachId = entity.UserPhuTrachId;
                    add.UserXuLyId = entity.UserXuLyId;
                    add.LinhVucCongViecId = entity.LinhVucCongViecId;
                    add.NoiDung = entity.NoiDung;
                    add.QuaTrinhXuLy = entity.QuaTrinhXuLy;
                    add.Status = entity.Status;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(HoSoCongViecResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.HoSoCongViecs.Create();

                    add.NgayHetHan = entity.NgayHetHan;
                    add.UserPhuTrachId = entity.UserPhuTrachId;
                    add.UserXuLyId = entity.UserXuLyId;
                    add.LinhVucCongViecId = entity.LinhVucCongViecId;
                    add.NoiDung = entity.NoiDung;
                    add.QuaTrinhXuLy = entity.QuaTrinhXuLy;
                    add.Status = entity.Status;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<HoSoCongViecResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    HoSoCongViec add;

                    foreach (var entity in entities)
                    {
                        add = context.HoSoCongViecs.Create();

                        add.NgayHetHan = entity.NgayHetHan;
                        add.UserPhuTrachId = entity.UserPhuTrachId;
                        add.UserXuLyId = entity.UserXuLyId;
                        add.LinhVucCongViecId = entity.LinhVucCongViecId;
                        add.NoiDung = entity.NoiDung;
                        add.QuaTrinhXuLy = entity.QuaTrinhXuLy;
                        add.Status = entity.Status;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<HoSoCongViecResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    HoSoCongViec add;

                    foreach (var entity in entities)
                    {
                        add = context.HoSoCongViecs.Create();

                        add.NgayHetHan = entity.NgayHetHan;
                        add.UserPhuTrachId = entity.UserPhuTrachId;
                        add.UserXuLyId = entity.UserXuLyId;
                        add.LinhVucCongViecId = entity.LinhVucCongViecId;
                        add.NoiDung = entity.NoiDung;
                        add.QuaTrinhXuLy = entity.QuaTrinhXuLy;
                        add.Status = entity.Status;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(HoSoCongViecResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var hs = context.HoSoCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    hs.IsDeleted = true;
                    hs.LastUpdatedBy = entity.LastUpdatedBy;
                    hs.LastUpdated = DateTime.Now;

                    context.Entry(hs).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(HoSoCongViecResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var hs = context.HoSoCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    hs.IsDeleted = true;
                    hs.LastUpdatedBy = entity.LastUpdatedBy;
                    hs.LastUpdated = DateTime.Now;

                    context.Entry(hs).State = EntityState.Modified;
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
                    var hs = context.HoSoCongViecs.Single(x => x.Id == id && x.IsDeleted == false);

                    hs.IsDeleted = true;
                    hs.LastUpdated = DateTime.Now;

                    context.Entry(hs).State = EntityState.Modified;
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
                    var hs = context.HoSoCongViecs.Single(x => x.Id == id && x.IsDeleted == false);

                    hs.IsDeleted = true;
                    hs.LastUpdated = DateTime.Now;

                    context.Entry(hs).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<HoSoCongViecResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.HoSoCongViecs
                        where item.IsDeleted == false
                        select new HoSoCongViecResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            UserPhuTrachId = item.UserPhuTrachId,
                            UserPhuTrach = item.User.ToIfNotNullDataInfo(),
                            UserXuLyId = item.UserXuLyId,
                            UserXyLy = item.User1.ToIfNotNullDataInfo(),
                            LinhVucCongViecId = item.LinhVucCongViecId,
                            LinhVucCongViec = item.LinhVucCongViec.ToIfNotNullDataInfo(),
                            NoiDung = item.NoiDung,
                            QuaTrinhXuLy = item.QuaTrinhXuLy,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
                }
            });
        }

        public async Task<IEnumerable<HoSoCongViecResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.HoSoCongViecs
                        where item.IsDeleted == false
                        select new HoSoCongViecResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            UserPhuTrachId = item.UserPhuTrachId,
                            UserPhuTrach = item.User.ToIfNotNullDataInfo(),
                            UserXuLyId = item.UserXuLyId,
                            UserXyLy = item.User1.ToIfNotNullDataInfo(),
                            LinhVucCongViecId = item.LinhVucCongViecId,
                            LinhVucCongViec = item.LinhVucCongViec.ToIfNotNullDataInfo(),
                            NoiDung = item.NoiDung,
                            QuaTrinhXuLy = item.QuaTrinhXuLy,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToListAsync();
                }
            });
        }

        public HoSoCongViecResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.HoSoCongViecs
                        where item.IsDeleted == false && item.Id == id
                        select new HoSoCongViecResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            UserPhuTrachId = item.UserPhuTrachId,
                            UserPhuTrach = item.User.ToIfNotNullDataInfo(),
                            UserXuLyId = item.UserXuLyId,
                            UserXyLy = item.User1.ToIfNotNullDataInfo(),
                            LinhVucCongViecId = item.LinhVucCongViecId,
                            LinhVucCongViec = item.LinhVucCongViec.ToIfNotNullDataInfo(),
                            NoiDung = item.NoiDung,
                            QuaTrinhXuLy = item.QuaTrinhXuLy,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).Single();
                }
            });
        }

        public async Task<HoSoCongViecResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.HoSoCongViecs
                        where item.IsDeleted == false && item.Id == id
                        select new HoSoCongViecResult
                        {
                            Id = item.Id,
                            NgayHetHan = item.NgayHetHan,
                            UserPhuTrachId = item.UserPhuTrachId,
                            UserPhuTrach = item.User.ToIfNotNullDataInfo(),
                            UserXuLyId = item.UserXuLyId,
                            UserXyLy = item.User1.ToIfNotNullDataInfo(),
                            LinhVucCongViecId = item.LinhVucCongViecId,
                            LinhVucCongViec = item.LinhVucCongViec.ToIfNotNullDataInfo(),
                            NoiDung = item.NoiDung,
                            QuaTrinhXuLy = item.QuaTrinhXuLy,
                            IsDeleted = item.IsDeleted,
                            CreateDate = item.CreateDate,
                            CreatedBy = item.CreatedBy,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).SingleAsync();
                }
            });
        }

        public SaveResult Update(HoSoCongViecResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.HoSoCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.NgayHetHan = entity.NgayHetHan;
                    update.UserPhuTrachId = entity.UserPhuTrachId;
                    update.UserXuLyId = entity.UserXuLyId;
                    update.LinhVucCongViecId = entity.LinhVucCongViecId;
                    update.NoiDung = entity.NoiDung;
                    update.QuaTrinhXuLy = entity.QuaTrinhXuLy;

                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(HoSoCongViecResult entity)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.HoSoCongViecs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.NgayHetHan = entity.NgayHetHan;
                    update.UserPhuTrachId = entity.UserPhuTrachId;
                    update.UserXuLyId = entity.UserXuLyId;
                    update.LinhVucCongViecId = entity.LinhVucCongViecId;
                    update.NoiDung = entity.NoiDung;
                    update.QuaTrinhXuLy = entity.QuaTrinhXuLy;

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