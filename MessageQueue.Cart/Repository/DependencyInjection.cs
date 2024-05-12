using MessageQueue.Cart.Repository.Implement;
using MessageQueue.Cart.Repository.Interface;

namespace MessageQueue.Cart.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IBooksCartRepository, BooksCartRepository>();
            services.Decorate<IBooksCartRepository, BooksCartCacheRepository>();


            services.AddScoped<IBooksCartItemRepository, BooksCartItemRepository>();
            services.Decorate<IBooksCartItemRepository, BooksCartItemCacheRepository>();

            services.AddScoped<UnitOfWork.IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }
}
