// ***********************************************************************
// Assembly         : TechOffice.Services
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-20-2016
// ***********************************************************************
// <copyright file="IDelete.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

/// <summary>
/// The Services namespace.
/// </summary>
namespace TechOffice.Services
{
    /// <summary>
    /// Interface IDelete
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IDelete<TEntity> where TEntity :class
    {
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        SaveResult Delete(TEntity entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<SaveResult> DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes the by.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        SaveResult DeleteBy(int Id);

        /// <summary>
        /// Deletes the by asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<SaveResult> DeleteByAsync(int Id);
    }
}
