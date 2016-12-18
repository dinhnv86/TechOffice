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
    public class NewsRepository : DbExecute, INewsRepository
    {
        public NewsRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(NewsResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    SaveResult result;
                    var add = context.News.Create();

                    add.Title = entity.Title;
                    add.Content = entity.Content;
                    add.Summary = entity.Summary;
                    add.UrlImage = entity.UrlImage;
                    add.NewsCategoryId = entity.NewsCategoryId;
                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;

                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                    entity.Id = add.Id;

                    return result;
                }
            });
        }

        public async Task<SaveResult> AddAsync(NewsResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.News.Create();

                    add.Title = entity.Title;
                    add.Content = entity.Content;
                    add.Summary = entity.Summary;
                    add.UrlImage = entity.UrlImage;
                    add.NewsCategoryId = entity.NewsCategoryId;
                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<NewsResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.News.Create();

                        add.Title = entity.Title;
                        add.Content = entity.Content;
                        add.Summary = entity.Summary;
                        add.UrlImage = entity.UrlImage;
                        add.NewsCategoryId = entity.NewsCategoryId;
                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<NewsResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.News.Create();

                        add.Title = entity.Title;
                        add.Content = entity.Content;
                        add.Summary = entity.Summary;
                        add.UrlImage = entity.UrlImage;
                        add.NewsCategoryId = entity.NewsCategoryId;
                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(NewsResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cq = context.News.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cq.IsDeleted = true;
                    cq.LastUpdatedBy = entity.LastUpdatedBy;
                    cq.LastUpdated = DateTime.Now;

                    context.Entry(cq).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(NewsResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var cq = context.News.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    cq.IsDeleted = true;
                    cq.LastUpdatedBy = entity.LastUpdatedBy;
                    cq.LastUpdated = DateTime.Now;

                    context.Entry(cq).State = EntityState.Modified;
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
                    var cq = context.News.Single(x => x.Id == id && x.IsDeleted == false);

                    cq.IsDeleted = true;
                    cq.LastUpdated = DateTime.Now;

                    context.Entry(cq).State = EntityState.Modified;
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
                    var cq = context.News.Single(x => x.Id == id && x.IsDeleted == false);

                    cq.IsDeleted = true;
                    cq.LastUpdated = DateTime.Now;

                    context.Entry(cq).State = EntityState.Modified;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<NewsResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.News
                            where item.IsDeleted == false
                            orderby item.CreateDate
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<NewsResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.News
                                  where item.IsDeleted == false
                                  orderby item.CreateDate
                                  select item)
                                  .MakeQueryToDatabase()
                                  .Select(x => x.ToDataResult())
                                  .AsQueryable()
                                  .ToListAsync();
                }
            });
        }

        public NewsResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.News
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .Single();
                }
            });
        }

        public async Task<NewsResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.News
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

        public SaveResult Update(NewsResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.News.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Title = entity.Title;
                    update.Content = entity.Content;
                    update.Summary = entity.Summary;
                    update.NewsCategoryId = entity.NewsCategoryId;
                    update.UrlImage = entity.UrlImage;

                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(NewsResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.News.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Title = entity.Title;
                    update.Content = entity.Content;
                    update.Summary = entity.Summary;
                    update.NewsCategoryId = entity.NewsCategoryId;
                    update.UrlImage = entity.UrlImage;

                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<NewsResult> GetAllByNewsCategoryId(int newsCategoryId)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.News
                            where item.IsDeleted == false
                            && item.NewsCategoryId == newsCategoryId
                            orderby item.CreateDate
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }
    }
}