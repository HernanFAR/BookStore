using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using RequestProcessorResource = SharedKernel.Properties.Application.PipelineBehaviors.TimewatchBehavior;
using SharedKernel.Infraestructure.MediatR;
using SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior.Configurations;
using SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior.Interfaces;

namespace SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior
{
    public class RequestProcessor<TRequest> : IRequestProcessor<TRequest>
    {
        private readonly TimewatchConfiguration _Configuration;
        private readonly IRequestInformation<TRequest> _RequestInformation;
        private readonly ILogger<TRequest> _Logger;

        private readonly Dictionary<RequestType, Action> _ProcessAction;

        public RequestProcessor(TimewatchConfiguration configuration, IRequestInformation<TRequest> requestInformation,
            ILogger<TRequest> logger)
        {
            _Configuration = configuration;
            _RequestInformation = requestInformation;
            _Logger = logger;

            _ProcessAction = new()
            {
                { RequestType.Other, ProcessOther },
                { RequestType.Command, ProcessCommand },
                { RequestType.Query, ProcessQuery }
            };
        }

        public void Process()
        {
            _ProcessAction[_RequestInformation.RequestType]();
        }

        private void ProcessOther()
        {
            if (_RequestInformation.Elapsed < _Configuration.MaxMilliSecondsForOthers) return;

            _Logger.Log(LogLevel.Warning, RequestProcessorResource.LanguageResources.ProcessTimewatch,
                _RequestInformation.RequestId, typeof(TRequest).Name, _RequestInformation.Elapsed,
                RequestProcessorResource.LanguageResources.Other, _Configuration.MaxMilliSecondsForOthers);
        }

        private void ProcessQuery()
        {
            if (_RequestInformation.Elapsed < _Configuration.MaxMilliSecondsForQueries) return;

            _Logger.Log(LogLevel.Warning, RequestProcessorResource.LanguageResources.ProcessTimewatch,
                _RequestInformation.RequestId, typeof(TRequest).Name, _RequestInformation.Elapsed,
                RequestProcessorResource.LanguageResources.Query, _Configuration.MaxMilliSecondsForQueries);
        }

        private void ProcessCommand()
        {
            if (_RequestInformation.Elapsed < _Configuration.MaxMilliSecondsForCommands) return;

            _Logger.Log(LogLevel.Warning, RequestProcessorResource.LanguageResources.ProcessTimewatch,
                _RequestInformation.RequestId, typeof(TRequest).Name, _RequestInformation.Elapsed,
                RequestProcessorResource.LanguageResources.Command, _Configuration.MaxMilliSecondsForCommands);
        }
    }
}
