using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TechOffice.Entities;
using TechOffice.Entities.Results;
using TechOffice.Services.Abstracts;
using TechOffice.Utilities;

namespace TechOffice.Services.Implements
{
    /// <summary>
    /// </summary>
    public class ChuVuRepository : IChuVuRepository
    {
        /// <summary>
        ///     The _log service
        /// </summary>
        private readonly ILogService _logService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChuVuRepository" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public ChuVuRepository(ILogService logService)
        {
            _logService = logService;
        }

        public SaveResult Add(ChucVuResult entity)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.ChucVus.Create();

                    add.Ten = entity.Ten;
                    add.MoTa = entity.MoTa;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        public async Task<SaveResult> AddAsync(ChucVuResult entity)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var add = context.ChucVus.Create();

                    add.Ten = entity.Ten;
                    add.MoTa = entity.MoTa;
                    add.IsDeleted = entity.IsDeleted;
                    add.LastUpdatedBy = entity.LastUpdatedBy;
                    add.LastUpdated = DateTime.Now;

                    context.Entry(add).State = EntityState.Added;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }
            return result;
        }

        public SaveResult AddRange(IEnumerable<ChucVuResult> entities)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    ChucVu add;
                    foreach (var entity in entities)
                    {
                        add = context.ChucVus.Create();

                        add.Ten = entity.Ten;
                        add.MoTa = entity.MoTa;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        public async Task<SaveResult> AddRangeAsync(IEnumerable<ChucVuResult> entities)
        {
            SaveResult result;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    ChucVu add;
                    foreach (var entity in entities)
                    {
                        add = context.ChucVus.Create();

                        add.Ten = entity.Ten;
                        add.MoTa = entity.MoTa;
                        add.IsDeleted = entity.IsDeleted;
                        add.LastUpdatedBy = entity.LastUpdatedBy;
                        add.LastUpdated = DateTime.Now;

                        context.Entry(add).State = EntityState.Added;
                    }

                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        public SaveResult Delete(ChucVuResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    chucvu.IsDeleted = true;

                    context.Entry(chucvu).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        public async Task<SaveResult> DeleteAsync(ChucVuResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);
                    chucvu.IsDeleted = true;

                    context.Entry(chucvu).State = EntityState.Modified;

                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        public SaveResult DeleteBy(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == id && x.IsDeleted == false);
                    chucvu.IsDeleted = true;

                    context.Entry(chucvu).State = EntityState.Modified;

                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        public async Task<SaveResult> DeleteByAsync(int id)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var chucvu = context.ChucVus.Single(x => x.Id == id && x.IsDeleted == false);
                    chucvu.IsDeleted = true;

                    context.Entry(chucvu).State = EntityState.Modified;

                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        public IEnumerable<ChucVuResult> GetAll()
        {
            IEnumerable<ChucVuResult> results = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = (from item in context.ChucVus
                        where item.IsDeleted == false
                        select new ChucVuResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return results;
        }

        public async Task<IEnumerable<ChucVuResult>> GetAllAsync()
        {
            IEnumerable<ChucVuResult> results = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    results = await (from item in context.ChucVus
                        where item.IsDeleted == false
                        select new ChucVuResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return results;
        }

        public ChucVuResult Single(int id)
        {
            ChucVuResult result = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    result = (from item in context.ChucVus
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new ChucVuResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).Single();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return result;
        }

        public async Task<ChucVuResult> SingleAsync(int id)
        {
            ChucVuResult result = null;
            try
            {
                using (var context = new TechOfficeEntities())
                {
                    result = await (from item in context.ChucVus
                        where item.IsDeleted == false &&
                              item.Id == id
                        select new ChucVuResult
                        {
                            Id = item.Id,
                            Ten = item.Ten,
                            MoTa = item.MoTa,
                            IsDeleted = item.IsDeleted,
                            LastUpdatedBy = item.LastUpdatedBy,
                            LastUpdated = item.LastUpdated
                        }).SingleAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return result;
        }

        public SaveResult Update(ChucVuResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Ten = entity.Ten;
                    update.MoTa = entity.MoTa;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }

        public async Task<SaveResult> UpdateAsync(ChucVuResult entity)
        {
            SaveResult result;

            try
            {
                using (var context = new TechOfficeEntities())
                {
                    var update = context.ChucVus.Single(x => x.Id == entity.Id && x.IsDeleted == false);

                    update.Ten = entity.Ten;
                    update.MoTa = entity.MoTa;
                    update.IsDeleted = entity.IsDeleted;
                    update.LastUpdatedBy = entity.LastUpdatedBy;
                    update.LastUpdated = DateTime.Now;

                    context.Entry(update).State = EntityState.Modified;

                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
                result = SaveResult.FAILURE;
            }

            return result;
        }
    }
}