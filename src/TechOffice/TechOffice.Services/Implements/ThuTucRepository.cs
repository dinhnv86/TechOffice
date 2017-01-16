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
    public class ThuTucRepository : DbExecute, IThuTucRepository
    {
        public ThuTucRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(ThuTucResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = entity.AddToDb(context);
                    var result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                    entity.Id = add.Id;

                    return result;
                }
            });
        }

        public async Task<SaveResult> AddAsync(ThuTucResult entity)
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

        public SaveResult AddRange(IEnumerable<ThuTucResult> entities)
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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<ThuTucResult> entities)
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

        public SaveResult Delete(ThuTucResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var tt = context.ThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    tt.DeleteToDb(context, entity.LastUpdatedBy);

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(ThuTucResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var tt = context.ThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    tt.DeleteToDb(context, entity.LastUpdatedBy);

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
                    var tt = context.ThuTucs.Single(x => x.Id == id && x.IsDeleted == false);

                    tt.DeleteToDb(context);

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
                    var tt = context.ThuTucs.Single(x => x.Id == id && x.IsDeleted == false);

                    tt.DeleteToDb(context);

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<ThuTucResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.ThuTucs
                        where item.IsDeleted == false
                        select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<ThuTucResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.ThuTucs
                        where item.IsDeleted == false
                        select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .ToListAsync();
                }
            });
        }

        public ThuTucResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.ThuTucs
                        .Include(x => x.TapTinThuTucs)
                        where item.IsDeleted == false && item.Id == id
                        select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .Single();
                }
            });
        }

        public async Task<ThuTucResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.ThuTucs
                        .Include(x => x.TapTinThuTucs)
                        where item.IsDeleted == false && item.Id == id
                        select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .AsQueryable()
                        .SingleAsync();
                }
            });
        }

        public SaveResult Update(ThuTucResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.ThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UpdateToDb(entity, context);

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(ThuTucResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.ThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UpdateToDb(entity, context);

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }
    }
}