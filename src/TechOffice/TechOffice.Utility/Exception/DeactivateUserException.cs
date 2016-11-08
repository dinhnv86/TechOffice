// ***********************************************************************
// Assembly         : AnThinhPhat.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="DeactivateUserException.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace AnThinhPhat.Utilities
{
    /// <summary>
    ///     Class DeactivateUserException.
    /// </summary>
    public class DeactivateUserException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DeactivateUserException" /> class.
        /// </summary>
        public DeactivateUserException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeactivateUserException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DeactivateUserException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeactivateUserException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        public DeactivateUserException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}