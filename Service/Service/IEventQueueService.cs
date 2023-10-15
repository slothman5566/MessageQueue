using MediatR;

namespace Service.Service
{
    public interface IEventQueueService
    {
        public Task Enqueue(IRequest request);
        
    }
}
