﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MessageQueue.Core.Data.Db
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
