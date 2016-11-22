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
using AnThinhPhat.Entities.Searchs;

namespace AnThinhPhat.Services.Implements
{
    public class TacNghiepRepository : DbExecute, ITacNghiepRepository
    {
        public TacNghiepRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(TacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    entity.AddToDb(context);
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(TacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    entity.AddToDb(context);
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<TacNghiepResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        entity.AddToDb(context);
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<TacNghiepResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        entity.AddToDb(context);
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(TacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(TacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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
                    var cv = context.TacNghieps.Single(x => x.Id == id && x.IsDeleted == false);

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
                    var cv = context.TacNghieps.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;

                    context.Entry(cv).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<TacNghiepResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghieps
                            .Include(i => i.TacNghiep_TinhHinhThucHien)
                            where item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<TacNghiepResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghieps
                                  where item.IsDeleted == false
                                  select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .ToListAsync();
                }
            });
        }

        public TacNghiepResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.TacNghieps
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .Single();
                }
            });
        }

        public async Task<TacNghiepResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.TacNghieps
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

        public SaveResult Update(TacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.NgayHetHan = entity.NgayHetHan;
                    update.NgayHoanThanh = entity.NgayHoanThanh;
                    update.NoiDung = entity.NoiDung;
                    update.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                    update.MucDoHoanThanhId = entity.MucDoHoanThanhId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(TacNghiepResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.TacNghieps.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.NgayHetHan = entity.NgayHetHan;
                    update.NgayHoanThanh = entity.NgayHoanThanh;
                    update.NoiDung = entity.NoiDung;
                    update.NoiDungTraoDoi = entity.NoiDungTraoDoi;
                    update.MucDoHoanThanhId = entity.MucDoHoanThanhId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddTacNghiepWithTinhHinhThucHien(TacNghiepResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                var result = SaveResult.FAILURE;

                using (var context = new TechOfficeEntities())
                {
                    using (var transaction = context.BeginTransaction())
                    {
                        entity.AddToDb(context);
                        var tt = context.TacNghieps.Local.FirstOrDefault();
                        if (tt != null)
                        {
                            foreach (var item in entity.CoQuanInfos)
                            {
                                var co = context.TacNghiep_TinhHinhThucHien.Create();

                                co.CoQuanId = item.Id;
                                co.TacNghiepId = tt.Id;
                                co.MucDoHoanThanhId = (int)EnumMucDoHoanThanh.CHUATHUHIEN;

                                co.IsDeleted = tt.IsDeleted;
                                co.CreatedBy = tt.CreatedBy;
                                co.CreateDate = tt.CreateDate;

                                context.Entry(co).State = EntityState.Added;
                            }
                        }
                        result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                        transaction.Commit();

                        entity.Id = tt.Id;
                    }
                }
                return result;
            });
        }

        public IEnumerable<TacNghiepResult> Find(ValueSearchTacNghiep valueSearch)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var query = (from item in context.TacNghieps
                                 where item.IsDeleted == false
                                 select item);

                    if (valueSearch.NhomCoquanId.HasValue)
                        query = query.Where(x => x.TacNghiep_TinhHinhThucHien.Any(y => y.CoQuan.NhomCoQuanId == valueSearch.NhomCoquanId.Value));

                    if (valueSearch.CoQuanId.HasValue)
                        query = query.Where(x => x.TacNghiep_TinhHinhThucHien.Any(y => y.Id == valueSearch.CoQuanId.Value));

                    if (valueSearch.LinhVucTacNghiepId.HasValue)
                        query = query.Where(x => x.LinhVucTacNghiepId == valueSearch.LinhVucTacNghiepId.Value);

                    if (valueSearch.MucDoHoanThanhId.HasValue)
                        query = query.Where(x => x.TacNghiep_TinhHinhThucHien.Any(y => y.MucDoHoanThanhId == valueSearch.MucDoHoanThanhId));

                    if (valueSearch.NamBanHanhId.HasValue)
                        query = query.Where(x => x.NgayTao.Year == valueSearch.NamBanHanhId.Value);

                    if (!string.IsNullOrEmpty(valueSearch.NoiDungTimKiem))
                    {
                        if (valueSearch.SearchTypeValue.HasValue && valueSearch.SearchTypeValue.Value)//Search by noi dung
                            query = query.Where(x => x.NoiDung.Contains(valueSearch.NoiDungTimKiem));
                        else//search by noi dung trao doi
                            query = query.Where(x => x.NoiDungTraoDoi.Contains(valueSearch.NoiDungTimKiem));
                    }
                    return query.MakeQueryToDatabase()
                      .Select(x => x.ToDataResult())
                      .ToList();
                }
            });
        }
    }
}