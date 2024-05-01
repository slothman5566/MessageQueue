using MediatR;
using Microsoft.Extensions.Logging;

namespace MessageQueue.Core.CQRS.Behavior
{
    public class LogBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LogBehavior<TRequest, TResponse>> _logger;
        public LogBehavior(ILogger<LogBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start Request:{Request} Date{Data}", typeof(TRequest).Name, request);
            var response = await next();
            _logger.LogInformation("End Request:{Rqeust} Response{Response}", typeof(TRequest).Name,typeof(TResponse).Name);
            return response;
        }
    }
}
