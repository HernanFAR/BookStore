using MediatR;

namespace SharedKernel.Infraestructure.MediatR.Requests
{
    public interface ICommand : ICommand<Unit>, IRequest
    { }

    public interface ICommand<TResponse> : IRequest<TResponse>
    { }
}
