using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GMediator.Interfaces;

namespace GMediator.Implementations
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
                throw new InvalidOperationException($"No handler found for request type {request.GetType().Name}");

            var method = handlerType.GetMethod("Handle");
            return await (Task<TResponse>)method.Invoke(handler, new object[] { request, cancellationToken })!;
        }
    }
}