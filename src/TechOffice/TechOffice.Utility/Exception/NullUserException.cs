// ***********************************************************************
// Assembly         : TechOffice.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="NullUserException.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// The Utilities namespace.
/// </summary>
namespace TechOffice.Utilities
{
    /// <summary>
    /// Class NullUserException.
    /// </summary>
    public class NullUserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullUserException" /> class.
        /// </summary>
        public NullUserException():base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="NullUserException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NullUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullUserException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public NullUserException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
