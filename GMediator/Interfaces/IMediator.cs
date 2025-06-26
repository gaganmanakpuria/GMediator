using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMediator.Interfaces
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}