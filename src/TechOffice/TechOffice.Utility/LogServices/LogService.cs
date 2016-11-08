// ***********************************************************************
// Assembly         : AnThinhPhat.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 03-13-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 03-14-2016
// ***********************************************************************
// <copyright file="ILogService.cs" company="Atmel Corporation">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;

/// <summary>
/// The Utilities namespace.
/// </summary>

namespace AnThinhPhat.Utilities
{
    /// <summary>
    ///     Class LogService.
    /// </summary>
    public class LogService : ILogService
    {
        /// <summary>
        ///     The  logger
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Error(object message, Exception e)
        {
            _logger.Error(message, e);
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(object message)
        {
            _logger.Error(message);
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Info(object message, Exception e)
        {
            _logger.Info(message, e);
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(object message)
        {
            _logger.Info(message);
        }

        /// <summary>
        ///     Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The e.</param>
        public void Warning(object message, Exception e)
        {
            _logger.Warn(message, e);
        }

        /// <summary>
        ///     Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(object message)
        {
            _logger.Warn(message);
        }

        /// <summary>
        ///     Set some additional attributes that will be logged by log4net
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        public void SetAdditionalAttributes(Dictionary<string, object> attributes)
        {
            if (attributes == null)
                return;
            foreach (var key in attributes.Keys)
            {
                ThreadContext.Properties[key] = attributes;
            }
        }
    }
}