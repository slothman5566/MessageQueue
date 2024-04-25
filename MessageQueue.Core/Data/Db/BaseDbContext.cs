using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MessageQueue.Core.Data.Db
{
    public class BaseDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
