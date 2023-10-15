using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class EventQueueService : IEventQueueService
    {
        private readonly IMediator _mediator;
        public EventQueueService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Enqueue(IRequest request)
        {
            await _mediator.Send(request);
        }
    }
}
