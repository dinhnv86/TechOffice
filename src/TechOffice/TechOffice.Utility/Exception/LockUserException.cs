// ***********************************************************************
// Assembly         : AnThinhPhat.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="LockUserException.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

/// <summary>
/// 
/// </summary>

namespace AnThinhPhat.Utilities
{
    /// <summary>
    /// </summary>
    public class LockUserException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LockUserException" /> class.
        /// </summary>
        public LockUserException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LockUserException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LockUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LockUserException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public LockUserException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}