using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Infraestructure.MediatR;
using SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior.Configurations;
using SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior.Interfaces;

namespace SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior
{
    public class TimewatchBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly TimewatchConfiguration _Configuration;
        private readonly IRequestInformation<TRequest> _RequestInformation;
        private readonly IRequestProcessor<TRequest>? _RequestProcesor;

        private readonly Stopwatch? _Stopwatch;

        public TimewatchBehavior(TimewatchConfiguration configuration,
            IRequestInformation<TRequest> requestInformation, IRequestProcessor<TRequest> requestProcesor)
        {
            _Configuration = configuration;
            _RequestInformation = requestInformation;

            if (_Configuration.AllowUse)
            {
                _RequestProcesor = requestProcesor;
                _Stopwatch = new();
            }
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _Stopwatch?.Start();

            try
            {
                return await next();
            }
            finally
            {
                _Stopwatch?.Stop();

                if (_Configuration.AllowUse)
                {
                    _RequestInformation.Elapsed = _Stopwatch!.ElapsedMilliseconds;

                    _RequestProcesor!.Process();
                }
            }
        }
    }
}
