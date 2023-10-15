using MediatR;
using Microsoft.Extensions.Logging;
using Service.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Handler
{
    public class TestReqpuestHandler : IRequestHandler<TestReqpuest>
    {
        private readonly ILogger _logger;

        public TestReqpuestHandler(ILogger<TestReqpuestHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(TestReqpuest request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);
            _logger.LogInformation("About page visited at {DT}",DateTime.UtcNow.ToLongTimeString());
        }
    }
}
