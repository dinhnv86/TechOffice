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
    public class CongViecPhoiHopRepository : DbExecute, ICongViecPhoiHopRepository
    {
        public CongViecPhoiHopRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(CongViecPhoiHopResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.CongViec_PhoiHop.Create();

                    add.HoSoCongViecId = entity.HoSoCongViecId;
                    add.UserId = entity.UserId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(CongViecPhoiHopResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.CongViec_PhoiHop.Create();

                    add.HoSoCongViecId = entity.HoSoCongViecId;
                    add.UserId = entity.UserId;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<CongViecPhoiHopResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.CongViec_PhoiHop.Create();
                        add.HoSoCongViecId = entity.HoSoCongViecId;
                        add.UserId = entity.UserId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<CongViecPhoiHopResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.CongViec_PhoiHop.Create();
                        add.HoSoCongViecId = entity.HoSoCongViecId;
                        add.UserId = entity.UserId;

                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(CongViecPhoiHopResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.CongViec_PhoiHop.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    cv.IsDeleted = true;
                    cv.LastUpdatedBy = entity.LastUpdatedBy;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(CongViecPhoiHopResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.CongViec_PhoiHop.Single(x => x.Id == entity.Id && x.IsDeleted == false);
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
                    var cv = context.CongViec_PhoiHop.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteByAsync(int id)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.CongViec_PhoiHop.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.IsDeleted = true;
                    cv.LastUpdated = DateTime.Now;

                    context.Entry(cv).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<CongViecPhoiHopResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.CongViec_PhoiHop
                            where item.IsDeleted == false
                            select new CongViecPhoiHopResult
                            {
                                Id = item.Id,
                                HoSoCongViecId = item.HoSoCongViecId,
                                HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                                UserId = item.UserId,
                                UserInfo = item.User.ToIfNotNullDataInfo(),
                                IsDeleted = item.IsDeleted,
                                CreateDate = item.CreateDate,
                                CreatedBy = item.CreatedBy,
                                LastUpdatedBy = item.LastUpdatedBy,
                                LastUpdated = item.LastUpdated
                            }).ToList();
                }
            });
        }

        public async Task<IEnumerable<CongViecPhoiHopResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.CongViec_PhoiHop
                                  where item.IsDeleted == false
                                  select new CongViecPhoiHopResult
                                  {
                                      Id = item.Id,
                                      HoSoCongViecId = item.HoSoCongViecId,
                                      HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                                      UserId = item.UserId,
                                      UserInfo = item.User.ToIfNotNullDataInfo(),
                                      IsDeleted = item.IsDeleted,
                                      CreateDate = item.CreateDate,
                                      CreatedBy = item.CreatedBy,
                                      LastUpdatedBy = item.LastUpdatedBy,
                                      LastUpdated = item.LastUpdated
                                  }).ToListAsync();
                }
            });
        }

        public CongViecPhoiHopResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.CongViec_PhoiHop
                            where item.IsDeleted == false
                            select new CongViecPhoiHopResult
                            {
                                Id = item.Id,
                                HoSoCongViecId = item.HoSoCongViecId,
                                HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                                UserId = item.UserId,
                                UserInfo = item.User.ToIfNotNullDataInfo(),
                                IsDeleted = item.IsDeleted,
                                CreateDate = item.CreateDate,
                                CreatedBy = item.CreatedBy,
                                LastUpdatedBy = item.LastUpdatedBy,
                                LastUpdated = item.LastUpdated
                            }).Single();
                }
            });
        }

        public async Task<CongViecPhoiHopResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.CongViec_PhoiHop
                                  where item.IsDeleted == false && item.Id == id
                                  select new CongViecPhoiHopResult
                                  {
                                      Id = item.Id,
                                      HoSoCongViecId = item.HoSoCongViecId,
                                      HoSoCongViec = item.HoSoCongViec.ToIfNotNullDataInfo(),
                                      UserId = item.UserId,
                                      UserInfo = item.User.ToIfNotNullDataInfo(),
                                      IsDeleted = item.IsDeleted,
                                      CreateDate = item.CreateDate,
                                      CreatedBy = item.CreatedBy,
                                      LastUpdatedBy = item.LastUpdatedBy,
                                      LastUpdated = item.LastUpdated
                                  }).SingleAsync();
                }
            });
        }

        public SaveResult Update(CongViecPhoiHopResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.CongViec_PhoiHop
                        .Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UserId = entity.UserId;
                    update.HoSoCongViecId = entity.HoSoCongViecId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(CongViecPhoiHopResult entity)
        {
            return await ExecuteDbWithHandle(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.CongViec_PhoiHop
                        .Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UserId = entity.UserId;
                    update.HoSoCongViecId = entity.HoSoCongViecId;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddOrUpdate(int congViecId, IEnumerable<CongViecPhoiHopResult> entities, string userName)
        {
            if (entities.Any())
            {
                //get all phoi hop by hosocongviecid
                using (var context = new TechOfficeEntities())
                {
                    var listPhoihop = context.CongViec_PhoiHop.Where(x => x.HoSoCongViecId == congViecId).Select(x => new { x.UserId, x.HoSoCongViecId }).ToList();
                    var listEntities = entities.Select(x => new { x.UserId, x.HoSoCongViecId });
                    //cac phan tu ton tai trong listPhoiHop nhun ko ton tai trong entites
                    var left = listPhoihop.Except(listEntities);
                    //lay ra cac phan tu ton tain trong entities nhung ko ton tai trong listPhoihop
                    var right = listEntities.Except(listPhoihop);
                    foreach (var item in left)
                    {
                        //remove
                        var remove = context.CongViec_PhoiHop.Where(x => x.HoSoCongViecId == item.HoSoCongViecId && x.UserId == item.UserId).Single();
                        remove.IsDeleted = true;
                        remove.LastUpdated = DateTime.Now;
                        remove.LastUpdatedBy = userName;
                        context.Entry(remove).State = EntityState.Modified;
                    }

                    foreach (var item in right)
                    {
                        //add
                        var add = context.CongViec_PhoiHop.Create();
                        add.HoSoCongViecId = item.HoSoCongViecId;
                        add.UserId = item.UserId;
                        add.CreatedBy = userName;
                        add.CreateDate = DateTime.Now;
                        add.IsDeleted = false;
                        context.Entry(add).State = EntityState.Modified;
                    }
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            return SaveResult.SUCCESS;
        }
    }
}