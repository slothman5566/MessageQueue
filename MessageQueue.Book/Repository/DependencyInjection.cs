using MessageQueue.Book.Repository.Implement;
using MessageQueue.Book.Repository.Interface;

namespace MessageQueue.Book.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {

            services.AddScoped<IBookRepository, BookRepository>();
            services.Decorate<IBookRepository, BookCacheRepository>();

            services.AddScoped<UnitOfWork.IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }
}
