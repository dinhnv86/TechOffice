﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.Entities.Searchs;
using System.Data.SqlClient;

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
                    add.DanhGiaCongViec = entity.DanhGiaCongViec;
                    add.TrangThaiCongViecId = entity.TrangThaiCongViecId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

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
                    add.DanhGiaCongViec = entity.DanhGiaCongViec;
                    add.TrangThaiCongViecId = entity.TrangThaiCongViecId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

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
                    foreach (var entity in entities)
                    {
                        var add = context.HoSoCongViecs.Create();

                        add.NgayHetHan = entity.NgayHetHan;
                        add.UserPhuTrachId = entity.UserPhuTrachId;
                        add.UserXuLyId = entity.UserXuLyId;
                        add.LinhVucCongViecId = entity.LinhVucCongViecId;
                        add.NoiDung = entity.NoiDung;
                        add.DanhGiaCongViec = entity.DanhGiaCongViec;
                        add.TrangThaiCongViecId = entity.TrangThaiCongViecId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

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
                    foreach (var entity in entities)
                    {
                        var add = context.HoSoCongViecs.Create();

                        add.NgayHetHan = entity.NgayHetHan;
                        add.UserPhuTrachId = entity.UserPhuTrachId;
                        add.UserXuLyId = entity.UserXuLyId;
                        add.LinhVucCongViecId = entity.LinhVucCongViecId;
                        add.NoiDung = entity.NoiDung;
                        add.DanhGiaCongViec = entity.DanhGiaCongViec;
                        add.TrangThaiCongViecId = entity.TrangThaiCongViecId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

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
                                DanhGiaCongViec = item.DanhGiaCongViec,
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
                                      DanhGiaCongViec = item.DanhGiaCongViec,
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
                            select item)
                            .MakeQueryToDatabase()
                            .Select(x => x.ToDataResult())
                            .Single();
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
                                      DanhGiaCongViec = item.DanhGiaCongViec,
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
                    update.DanhGiaCongViec = entity.DanhGiaCongViec;
                    update.TrangThaiCongViecId = entity.TrangThaiCongViecId;

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
                    update.DanhGiaCongViec = entity.DanhGiaCongViec;

                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<HoSoCongViecResult> Find(ValueSearchCongViec valueSearch)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var query = (from item in context.HoSoCongViecs.Include(x => x.User)
                                 where item.IsDeleted == false
                                 select item);

                    if (valueSearch.From.HasValue && valueSearch.To.HasValue)
                        query = query.Where(x => x.NgayTao >= valueSearch.From.Value && x.NgayTao <= valueSearch.To.Value);

                    if (valueSearch.NhanVienId.HasValue)
                    {
                        if (valueSearch.Role.HasValue)
                        {
                            switch (valueSearch.Role.Value)
                            {
                                case EnumRoleExecute.PHOIHOP:
                                    query = query.Where(x => x.CongViec_PhoiHop.Any(y => y.UserId == valueSearch.NhanVienId.Value));
                                    break;
                                case EnumRoleExecute.PHUTRACH:
                                    query = query.Where(x => x.UserPhuTrachId == valueSearch.NhanVienId.Value);
                                    break;
                                case EnumRoleExecute.XULYCHINH:
                                    query = query.Where(x => x.UserXuLyId == valueSearch.NhanVienId.Value);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            query = query.Where(x => x.CongViec_PhoiHop.Any(y => y.UserId == valueSearch.NhanVienId.Value)
                              || x.UserPhuTrachId == valueSearch.NhanVienId.Value
                              || x.UserXuLyId == valueSearch.NhanVienId.Value);
                        }
                    }

                    if (valueSearch.TrangThaiCongViecId.HasValue)
                        query = query.Where(x => x.TrangThaiCongViecId == valueSearch.TrangThaiCongViecId);

                    if (valueSearch.LinhVucCongViecId.HasValue)
                        query = query.Where(x => x.LinhVucCongViecId == valueSearch.LinhVucCongViecId.Value);

                    if (!string.IsNullOrEmpty(valueSearch.NoiDungCongViec))
                        query = query.Where(x => x.NoiDung.Contains(valueSearch.NoiDungCongViec));

                    if (!string.IsNullOrEmpty(valueSearch.SoVanBan))
                        query = query.Where(x => x.CongViec_VanBan.Any(y => y.SoVanBan.Contains(valueSearch.SoVanBan)));

                    if (!string.IsNullOrEmpty(valueSearch.NoiDungVanBan))
                        query = query.Where(x => x.CongViec_VanBan.Any(y => y.NoiDung.Contains(valueSearch.NoiDungVanBan)));

                    if (valueSearch.CoQuanId.HasValue)
                        query = query.Where(x => x.CongViec_VanBan.Any(y => y.CoQuanId == valueSearch.CoQuanId.Value));

                    return query.OrderBy(x => x.TrangThaiCongViecId)
                    .MakeQueryToDatabase()
                    .Select(x => x.ToDataResult())
                    .ToList();
                }
            });
        }

        public SaveResult AddCongViecWithChildren(HoSoCongViecResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                var saveResult = SaveResult.FAILURE;

                using (var context = new TechOfficeEntities())
                {
                    using (var transaction = context.BeginTransaction())
                    {
                        entity.AddWithChildrenToDb(context);
                        var cv = context.HoSoCongViecs.Local.FirstOrDefault();

                        saveResult = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                        transaction.Commit();

                        entity.Id = cv != null ? cv.Id : 0;

                        return saveResult;
                    }
                }
            });
        }

        public IEnumerable<StatisticCongViec> Statistic(DateTime from, DateTime to)
        {
            using (var context = new TechOfficeEntities())
            {
                var items = context.Database.SqlQuery<StatisticCongViec>("Statictis @NoiVuId, @From, @To",
                    new SqlParameter("NoiVuId", TechOfficeConfig.IDENTITY_PHONGNOIVU),
                    new SqlParameter("From", from),
                    new SqlParameter("To", to)).ToList();

                return items;
            }
        }

        public IEnumerable<SummariesCongViecResult> Summaries(DateTime from, DateTime to)
        {
            using (var context = new TechOfficeEntities())
            {
                var items = context.Database.SqlQuery<SummariesCongViecResult>("Summaries @NoiVuId, @From, @To",
                    new SqlParameter("NoiVuId", TechOfficeConfig.IDENTITY_PHONGNOIVU),
                    new SqlParameter("From", from),
                    new SqlParameter("To", to)).ToList();

                return items;
            }
        }
    }
}