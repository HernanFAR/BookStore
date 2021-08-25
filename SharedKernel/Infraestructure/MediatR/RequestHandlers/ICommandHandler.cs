using MediatR;
using SharedKernel.Infraestructure.MediatR.Requests;

namespace SharedKernel.Infraestructure.MediatR.RequestHandlers
{
    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest>
         where TRequest : ICommand, IRequest<Unit>
    { }

    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
         where TRequest : ICommand<TResponse>, IRequest<TResponse>
    { }
}
