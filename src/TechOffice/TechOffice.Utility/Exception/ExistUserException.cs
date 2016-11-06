// ***********************************************************************
// Assembly         : TechOffice.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="ExistUserException.cs" company="Atmel Corporation">
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
    /// Class ExistUserException.
    /// </summary>
    public class ExistUserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExistUserException" /> class.
        /// </summary>
        public ExistUserException():base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExistUserException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExistUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistUserException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public ExistUserException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}
