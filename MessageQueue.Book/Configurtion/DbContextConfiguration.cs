using MessageQueue.Book.Data.Db;
using MessageQueue.Core.Data.Interceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace MessageQueue.Book.Configurtion
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddDbContext<LibraryDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseNpgsql(configuration.GetConnectionString("Database"));
            });

            services.AddScoped<ILibraryDbContext, LibraryDbContext>();

            return services;
        }
    }
}
