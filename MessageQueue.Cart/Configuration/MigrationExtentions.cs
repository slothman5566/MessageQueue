using MessageQueue.Cart.Data.Db;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Cart.Configuration
{
    public static class MigrationExtentions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<CartDbContext>();
            dbContext.Database.Migrate();

            return app;
        }
    }
}
