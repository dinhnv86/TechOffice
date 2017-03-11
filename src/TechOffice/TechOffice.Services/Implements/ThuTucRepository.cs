using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using System.Data;

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
                    using (var transaction = context.BeginTransaction())
                    {
                        var add = entity.AddToDb(context);
                        var result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                        transaction.Commit();

                        entity.Id = add.Id;

                        return result;
                    }
                }
            });
        }

        public async Task<SaveResult> AddAsync(ThuTucResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    using (var transaction = context.BeginTransaction())
                    {
                        entity.AddToDb(context);
                        var result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                        transaction.Commit();

                        return result;
                    }
                }
            });
        }

        public SaveResult AddRange(IEnumerable<ThuTucResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    using (var transaction = context.BeginTransaction())
                    {
                        foreach (var entity in entities)
                        {
                            entity.AddToDb(context);
                        }

                        var result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                        transaction.Commit();

                        return result;
                    }
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<ThuTucResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    using (var transaction = context.BeginTransaction())
                    {
                        foreach (var entity in entities)
                        {
                            entity.AddToDb(context);
                        }

                        var result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;

                        transaction.Commit();

                        return result;
                    }
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

                    InsertOrDeleteThuTucCoQuanThucHien(entity, context);

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

                    InsertOrDeleteThuTucCoQuanThucHien(entity, context);

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        private void InsertOrDeleteThuTucCoQuanThucHien(ThuTucResult entity, TechOfficeEntities context)
        {
            if (entity.CoQuanThucHienIds != null && entity.CoQuanThucHienIds.Count() > 0)
            {
                //search all thutuc_coquanthuchien by thutucId
                var searchAll = context.ThuTuc_CoQuanThucHien.Where(x => x.ThuTucId == entity.Id);

                searchAll.ToList().ForEach(x =>
                {
                    if (!entity.CoQuanThucHienIds.Contains(x.CoQuanId))
                    {
                        context.Entry(x).State = EntityState.Deleted;
                    }
                });

                entity.CoQuanThucHienIds.ToList().ForEach(x =>
                {
                    if (!searchAll.Select(y => y.CoQuanId).Contains(x))//not exists
                    {
                        //then insert a record
                        var insert = context.ThuTuc_CoQuanThucHien.Create();
                        insert.ThuTucId = entity.Id;
                        insert.CoQuanId = x;
                        insert.IsDeleted = false;
                        insert.CreateDate = entity.CreateDate;
                        insert.CreatedBy = entity.CreatedBy;

                        context.Entry(insert).State = EntityState.Added;
                    }
                });
            }
        }
    }
}