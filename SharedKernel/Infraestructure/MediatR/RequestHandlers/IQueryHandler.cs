using MediatR;
using SharedKernel.Infraestructure.MediatR.Requests;

namespace SharedKernel.Infraestructure.MediatR.RequestHandlers
{
    public interface IQueryHandler<TRequest> : IRequestHandler<TRequest>
         where TRequest : IQuery, IRequest<Unit>
    { }

    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
         where TRequest : IQuery<TResponse>, IRequest<TResponse>
    { }
}
