// ***********************************************************************
// Assembly         : TechOffice.Services
// Author           : tranthiencdsp@gmail.com
// Created          : 03-13-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="IRepository.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnThinhPhat.Services.Repositories
{
    /// <summary>
    ///     Interface IRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        TEntity Single(int id);

        /// <summary>
        ///     Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        Task<TEntity> SingleAsync(int id);

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <returns>IEnumerable&lt;TEntity&gt;.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        ///     Gets all asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;TEntity&gt;&gt;.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SaveResult.</returns>
        SaveResult Update(TEntity entity);

        /// <summary>
        ///     Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;SaveResult&gt;.</returns>
        Task<SaveResult> UpdateAsync(TEntity entity);

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        SaveResult Add(TEntity entity);

        /// <summary>
        ///     Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<SaveResult> AddAsync(TEntity entity);

        /// <summary>
        ///     Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        SaveResult AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        Task<SaveResult> AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        SaveResult Delete(TEntity entity);

        /// <summary>
        ///     Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<SaveResult> DeleteAsync(TEntity entity);

        /// <summary>
        ///     Deletes the by.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SaveResult DeleteBy(int id);

        /// <summary>
        ///     Deletes the by asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<SaveResult> DeleteByAsync(int id);
    }
}