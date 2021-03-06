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
    public class LinhVucThuTucRepository : DbExecute, ILinhVucThuTucRepository
    {
        public LinhVucThuTucRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(LinhVucThuTucResult entity)
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

        public async Task<SaveResult> AddAsync(LinhVucThuTucResult entity)
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

        public SaveResult AddRange(IEnumerable<LinhVucThuTucResult> entities)
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

        public async Task<SaveResult> AddRangeAsync(IEnumerable<LinhVucThuTucResult> entities)
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

        public SaveResult Delete(LinhVucThuTucResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var tt = context.LinhVucThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    tt.DeleteToDb(context, entity.LastUpdatedBy);

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(LinhVucThuTucResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var tt = context.LinhVucThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

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
                    var tt = context.LinhVucThuTucs.Single(x => x.Id == id && x.IsDeleted == false);

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
                    var tt = context.LinhVucThuTucs.Single(x => x.Id == id && x.IsDeleted == false);

                    tt.DeleteToDb(context);

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<LinhVucThuTucResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.LinhVucThuTucs
                            where item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<LinhVucThuTucResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.LinhVucThuTucs
                                  where item.IsDeleted == false
                                  select item)
                                  .MakeQueryToDatabase()
                                  .Select(x => x.ToDataResult())
                                  .AsQueryable()
                                  .ToListAsync();
                }
            });
        }

        public LinhVucThuTucResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.LinhVucThuTucs
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item)
                            .MakeQueryToDatabase()
                            .Select(x => x.ToDataResult())
                            .Single();
                }
            });
        }

        public async Task<LinhVucThuTucResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.LinhVucThuTucs
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

        public SaveResult Update(LinhVucThuTucResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.LinhVucThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UpdateToDb(entity, context);

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(LinhVucThuTucResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.LinhVucThuTucs.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UpdateToDb(entity, context);

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }
    }
}