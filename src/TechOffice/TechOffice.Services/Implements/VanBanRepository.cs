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
    public class VanBanRepository : DbExecute, IVanBanRepository
    {
        public VanBanRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(VanBanResult entity)
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

        public async Task<SaveResult> AddAsync(VanBanResult entity)
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

        public SaveResult AddRange(IEnumerable<VanBanResult> entities)
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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<VanBanResult> entities)
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

        public SaveResult Delete(VanBanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.VanBans.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.DeleteToDb(context, entity.LastUpdatedBy);
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(VanBanResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cv = context.VanBans.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cv.DeleteToDb(context, entity.LastUpdatedBy);
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
                    var cv = context.VanBans.Single(x => x.Id == id && x.IsDeleted == false);
                    cv.DeleteToDb(context);

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
                    var cv = context.VanBans.Single(x => x.Id == id && x.IsDeleted == false);

                    cv.DeleteToDb(context);
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<VanBanResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.VanBans.Include(x => x.TapTinVanBans)
                            where item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<VanBanResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.VanBans
                                  where item.IsDeleted == false
                                  select item)
                                  .MakeQueryToDatabase()
                                  .Select(x => x.ToDataResult())
                                  .AsQueryable()
                                  .ToListAsync();
                }
            });
        }

        public VanBanResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.VanBans
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item)
                            .MakeQueryToDatabase()
                            .Select(x => x.ToDataResult())
                            .Single();
                }
            });
        }

        public async Task<VanBanResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.VanBans
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

        public SaveResult Update(VanBanResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.VanBans.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UpdateToDb(entity, context);

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(VanBanResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.VanBans.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UpdateToDb(entity, context);

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }
    }
}