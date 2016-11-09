﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnThinhPhat.Services
{
    public static class Extension
    {
        public static DbConnection OpenConnection(this DbContext context)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }
            return objectContext.Connection;
        }

        public static DbTransaction BeginTransaction(this DbContext context)
        {
            return context.OpenConnection().BeginTransaction();
        }
    }
}