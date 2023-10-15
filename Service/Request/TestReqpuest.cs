using MediatR;

namespace Service.Request
{
    public class TestReqpuest : IRequest
    {
        public DateTime StartAt { get; set; }


        public string TaskName { get; set; }
    }
}
