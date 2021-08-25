using SharedKernel.Infraestructure.MediatR.Requests;
using System;
using System.Linq;

namespace SharedKernel.Infraestructure.MediatR
{
    public interface IRequestInformation<TRequest>
    {
        Guid RequestId { get; }

        long Elapsed { get; set; }

        RequestType RequestType { get; }
    }

    public class RequestInformation<TRequest> : IRequestInformation<TRequest>
    {
        private static readonly Type _QueryType = typeof(IQuery<>);
        private static readonly Type _CommandType = typeof(ICommand<>);
        private static readonly Type _RequestType = typeof(TRequest);

        public RequestInformation()
        {
            RequestId = Guid.NewGuid();

            RequestType = DeterminateRequestType();
        }

        private static RequestType DeterminateRequestType()
        {
            var isQuery = _RequestType.GetInterfaces()
               .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == _QueryType);

            if (isQuery) return RequestType.Query;

            var isCommand = _RequestType.GetInterfaces()
               .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == _CommandType);

            if (isCommand) return RequestType.Command;

            return RequestType.Other;
        }

        public Guid RequestId { get; private set; }

        public RequestType RequestType { get; }

        public long Elapsed { get; set; }
    }
}
