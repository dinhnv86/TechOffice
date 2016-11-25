// ***********************************************************************
// Assembly         : AnThinhPhat.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 03-13-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="MailType.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Utilities namespace.
/// </summary>

namespace AnThinhPhat.Utilities
{
    /// <summary>
    ///     Enum MailType
    /// </summary>
    public enum MailType
    {
        /// <summary>
        ///     The normal
        /// </summary>
        Normal = 0,

        /// <summary>
        ///     The register
        /// </summary>
        Register = 1,

        /// <summary>
        ///     The recover pass
        /// </summary>
        RecoverPass = 2,

        Feedback = 3,
    }
}