// ***********************************************************************
// Assembly         : TechOffice.Services
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-13-2016
// ***********************************************************************
// <copyright file="IAdd.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;

namespace AnThinhPhat.Services.Repositories
{
    /// <summary>
    ///     Interface IAdd
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IAdd<in TEntity> where TEntity : class
    {
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
    }
}