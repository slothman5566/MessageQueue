using MessageQueue.Book.Data.Db;
using Microsoft.EntityFrameworkCore;

namespace MessageQueue.Book.Configurtion
{
    public static class MigrationExtentions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            dbContext.Database.Migrate();

            return app;
        }
    }
}
