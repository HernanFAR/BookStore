using MediatR;

namespace SharedKernel.Infraestructure.MediatR.Requests
{
    public interface IQuery : IQuery<Unit>, IRequest
    { }

    public interface IQuery<TResponse> : IRequest<TResponse>
    { }
}
