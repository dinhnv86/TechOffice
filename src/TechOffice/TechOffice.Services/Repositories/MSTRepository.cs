// ***********************************************************************
// Assembly         : TechOffice.Services
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-13-2016
// ***********************************************************************
// <copyright file="MSTRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechOffice.Utilities;

/// <summary>
/// The Model namespace.
/// </summary>
namespace TechOffice.Model
{
    /// <summary>
    /// Class MSTRepository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public class MSTRepository<TEntity> : IMSTRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The _log service
        /// </summary>
        private ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTRepository{TEntity}" /> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public MSTRepository(ILogService logService)
        {
            this._logService = logService;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SaveResult.</returns>
        public SaveResult Add(TEntity entity)
        {
            var result = SaveResult.FAILURE;
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    context.Entry<TEntity>(entity).State = EntityState.Added;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return result;
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        public async Task<SaveResult> AddAsync(TEntity entity)
        {
            var result = SaveResult.FAILURE;
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    context.Entry<TEntity>(entity).State = EntityState.Added;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return result;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SaveResult.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public SaveResult Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<SaveResult> DeleteAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the by.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>SaveResult.</returns>
        public SaveResult DeleteBy(int id)
        {
            var result = SaveResult.FAILURE;
            var isSingle = IsSingle(id);
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    var entity = context.Set<TEntity>().Single(isSingle);
                    typeof(TEntity).GetProperty("IsDelete").SetValue(entity, true);
                    context.Entry<TEntity>(entity).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// delete by as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        public async Task<SaveResult> DeleteByAsync(int id)
        {
            var result = SaveResult.FAILURE;
            var isSingle = IsSingle(id);
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    var entity = context.Set<TEntity>().Single(isSingle);
                    typeof(TEntity).GetProperty("IsDeleted").SetValue(entity, true);
                    context.Entry<TEntity>(entity).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        public TEntity Single(int id)
        {
            TEntity result = null;
            var isSingle = IsSingle(id);
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    result = context.Set<TEntity>().Single(isSingle);
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// single as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public async Task<TEntity> SingleAsync(int id)
        {
            TEntity result = null;
            var isSingle = IsSingle(id);
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    result = await context.Set<TEntity>().SingleAsync(isSingle);
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> results = null;
            var isDelete = IsDelete();
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    results = context.Set<TEntity>().Where(isDelete).ToList();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }
            return results;
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> result = null;

            var isDelete = IsDelete();

            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    result = await context.Set<TEntity>().Where(isDelete).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SaveResult.</returns>
        public SaveResult Update(TEntity entity)
        {
            var result = SaveResult.FAILURE;
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    context.Entry<TEntity>(entity).State = EntityState.Modified;
                    result = context.SaveChanges() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return result;
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        public async Task<SaveResult> UpdateAsync(TEntity entity)
        {
            var result = SaveResult.FAILURE;
            try
            {
                using (EBROnlineEntities context = new EBROnlineEntities())
                {
                    context.Entry<TEntity>(entity).State = EntityState.Modified;
                    result = await context.SaveChangesAsync() > 0 ? SaveResult.SUCCESS : SaveResult.FAILURE;
                }
            }
            catch (Exception ex)
            {
                _logService.Error(ex.Message, ex);
            }

            return result;
        }

        /// <summary>
        /// Determines whether this instance is delete.
        /// </summary>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        private Expression<Func<TEntity, bool>> IsDelete()
        {
            var param = Expression.Parameter(typeof(TEntity));
            var comparisonExpression = Expression.Equal(Expression.Property(param, "IsDeleted"), Expression.Constant(false));

            return Expression.Lambda<Func<TEntity, bool>>(comparisonExpression, param);
        }

        /// <summary>
        /// Determines whether the specified identifier is single.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Expression&lt;Func&lt;TEntity, System.Boolean&gt;&gt;.</returns>
        private Expression<Func<TEntity, bool>> IsSingle(int id)
        {
            var param = Expression.Parameter(typeof(TEntity));
            //var comparisonExpression = Expression.Equal(Expression.Property(param, "Id"), Expression.Constant(id));
            var comparisonExpression = Expression.And(Expression.Equal(Expression.Property(param, "Id"), Expression.Constant(id)), Expression.Equal(Expression.Property(param, "IsDeleted"), Expression.Constant(false)));

            return Expression.Lambda<Func<TEntity, bool>>(comparisonExpression, param);
        }
    }
}
