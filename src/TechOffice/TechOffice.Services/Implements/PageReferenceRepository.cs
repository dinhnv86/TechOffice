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
    /// <summary>
    /// </summary>
    public class PageReferenceRepository : DbExecute, IPageReferenceRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChucVuRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public PageReferenceRepository(ILogService logService) : base(logService)
        {
        }

        public SaveResult Add(PageReferenceResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.PageReferences.Create();

                    add.UrlImage = entity.UrlImage;
                    add.UrlLink = entity.UrlLink;
                    add.IsNewPage = entity.IsNewPage;
                    add.Alt = entity.Alt;

                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    var result = context.SaveChanges();

                    entity.Id = add.Id;

                    return result > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddAsync(PageReferenceResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.PageReferences.Create();

                    add.UrlImage = entity.UrlImage;
                    add.UrlLink = entity.UrlLink;
                    add.IsNewPage = entity.IsNewPage;
                    add.Alt = entity.Alt;
                    add.IsDeleted = entity.IsDeleted;
                    add.CreatedBy = entity.CreatedBy;
                    add.CreateDate = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult AddRange(IEnumerable<PageReferenceResult> entities)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.PageReferences.Create();

                        add.UrlImage = entity.UrlImage;
                        add.UrlLink = entity.UrlLink;
                        add.IsNewPage = entity.IsNewPage;
                        add.Alt = entity.Alt;
                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<PageReferenceResult> entities)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    foreach (var entity in entities)
                    {
                        var add = context.PageReferences.Create();

                        add.UrlImage = entity.UrlImage;
                        add.UrlLink = entity.UrlLink;
                        add.IsNewPage = entity.IsNewPage;
                        add.Alt = entity.Alt;
                        add.IsDeleted = entity.IsDeleted;
                        add.CreatedBy = entity.CreatedBy;
                        add.CreateDate = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public SaveResult Delete(PageReferenceResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var page = context.PageReferences.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    page.IsDeleted = true;
                    page.LastUpdatedBy = entity.LastUpdatedBy;
                    page.LastUpdated = DateTime.Now;

                    context.Entry(page).State = EntityState.Modified;
                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> DeleteAsync(PageReferenceResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var page = context.PageReferences.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    page.IsDeleted = true;
                    page.LastUpdatedBy = entity.LastUpdatedBy;
                    page.LastUpdated = DateTime.Now;

                    context.Entry(page).State = EntityState.Modified;

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
                    var page = context.PageReferences.Single(x => x.Id == id && x.IsDeleted == false);

                    page.IsDeleted = true;
                    page.LastUpdated = DateTime.Now;

                    context.Entry(page).State = EntityState.Modified;

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
                    var page = context.PageReferences.Single(x => x.Id == id && x.IsDeleted == false);
                    page.IsDeleted = true;

                    context.Entry(page).State = EntityState.Modified;

                    return await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public IEnumerable<PageReferenceResult> GetAll()
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.PageReferences
                            where item.IsDeleted == false
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult())
                        .ToList();
                }
            });
        }

        public async Task<IEnumerable<PageReferenceResult>> GetAllAsync()
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await
                        (from item in context.PageReferences
                         where item.IsDeleted == false
                         select new PageReferenceResult
                         {
                             Id = item.Id,
                             UrlImage = item.UrlImage,
                             UrlLink = item.UrlLink,
                             IsNewPage = item.IsNewPage,
                             Alt = item.Alt,
                             IsDeleted = item.IsDeleted,
                             CreateDate = item.CreateDate,
                             CreatedBy = item.CreatedBy,
                             LastUpdatedBy = item.LastUpdatedBy,
                             LastUpdated = item.LastUpdated
                         }).ToListAsync();
                }
            });
        }

        public PageReferenceResult Single(int id)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return (from item in context.PageReferences
                            where item.IsDeleted == false &&
                                  item.Id == id
                            select item)
                        .MakeQueryToDatabase()
                        .Select(x => x.ToDataResult()).Single();
                }
            });
        }

        public async Task<PageReferenceResult> SingleAsync(int id)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    return await (from item in context.PageReferences
                                  where item.IsDeleted == false &&
                                        item.Id == id
                                  select new PageReferenceResult
                                  {
                                      Id = item.Id,
                                      UrlImage = item.UrlImage,
                                      UrlLink = item.UrlLink,
                                      IsNewPage = item.IsNewPage,
                                      Alt = item.Alt,
                                      IsDeleted = item.IsDeleted,
                                      CreateDate = item.CreateDate,
                                      CreatedBy = item.CreatedBy,
                                      LastUpdatedBy = item.LastUpdatedBy,
                                      LastUpdated = item.LastUpdated
                                  }).SingleAsync();
                }
            });
        }

        public SaveResult Update(PageReferenceResult entity)
        {
            return ExecuteDbWithHandle(_logService, () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.PageReferences.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UrlImage = entity.UrlImage;
                    update.UrlLink = entity.UrlLink;
                    update.IsNewPage = entity.IsNewPage;
                    update.Alt = entity.Alt;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    return context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            });
        }

        public async Task<SaveResult> UpdateAsync(PageReferenceResult entity)
        {
            return await ExecuteDbWithHandleAsync(_logService, async () =>
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.PageReferences.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.UrlImage = entity.UrlImage;
                    update.UrlLink = entity.UrlLink;
                    update.IsNewPage = entity.IsNewPage;
                    update.Alt = entity.Alt;
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