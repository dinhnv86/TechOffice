// ***********************************************************************
// Assembly         : TechOffice.Services
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-20-2016
// ***********************************************************************
// <copyright file="ISingle.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;

namespace AnThinhPhat.Services.Repositories
{
    /// <summary>
    ///     Create interface ISingle for Entity
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISingle<TEntity> where TEntity : class
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
    }
}