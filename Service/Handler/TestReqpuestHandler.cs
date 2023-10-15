using MediatR;
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
        public async Task Handle(TestReqpuest request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);

        }
    }
}
