// ***********************************************************************
// Assembly         : TechOffice.Model
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-20-2016
// ***********************************************************************
// <copyright file="IMSTRepository.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using TechOffice.Model.DTO;

/// <summary>
/// The Model namespace.
/// </summary>
namespace TechOffice.Model
{
    /// <summary>
    /// Interface IMSTRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IMSTRepository<TEntity> : IAdd<TEntity>, IDelete<TEntity>, ISingle<TEntity>, IGet<TEntity>, IUpdate<TEntity> where TEntity : class
    {
    }
}
