
using GMediator.Interfaces;

namespace MediatorTest
{
    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Handled: {request.Message}");
        }
    }
}

