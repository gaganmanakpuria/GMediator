using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMediator.Interfaces
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}