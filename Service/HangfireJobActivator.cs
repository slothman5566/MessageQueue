using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Service.Service;

namespace Service
{
    public class HangfireJobActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;


        public HangfireJobActivator(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
        }


        public override object ActivateJob(Type type)
        {
            return _serviceProvider.CreateScope().ServiceProvider.GetRequiredService(type);
        }
    }
}
