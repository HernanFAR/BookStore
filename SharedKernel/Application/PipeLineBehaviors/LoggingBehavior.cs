using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using LoggingBehaviorResource = SharedKernel.Properties.Application.PipelineBehaviors.LoggingBehavior;
using SharedKernel.Infraestructure.MediatR;
using SharedKernel.Domain.Exceptions;

namespace SharedKernel.Application.PipeLineBehaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<TRequest> _Logger;
        private readonly IRequestInformation<TRequest> _RequestInformation;

        public LoggingBehavior(ILogger<TRequest> logger, IRequestInformation<TRequest> requestInformation)
        {
            _Logger = logger;
            _RequestInformation = requestInformation;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var actionGuid = _RequestInformation.RequestId;
            var startedDate = DateTime.Now;
            var success = false;

            _Logger.LogInformation(
                LoggingBehaviorResource.LanguageResources.InitialLog,
                actionGuid, startedDate, typeof(TRequest).Name);

            try
            {
                var response = await next();
                success = true;

                _Logger.LogInformation(
                    LoggingBehaviorResource.LanguageResources.SuccessLog,
                    actionGuid, DateTime.Now, typeof(TRequest).Name);

                return response;
            }
            catch (ValidationException)
            {
                _Logger.LogWarning(
                    LoggingBehaviorResource.LanguageResources.ValidationExceptionLog,
                    actionGuid, DateTime.Now, typeof(TRequest).Name);

                throw;
            }
            catch (BussinessException ex)
            {
                _Logger.LogWarning(
                    LoggingBehaviorResource.LanguageResources.BussinessExceptionLog,
                    actionGuid, DateTime.Now, typeof(TRequest).Name, ex.Message, (int)ex.StatusCode);

                throw;
            }
            catch (Exception ex)
            {
                _Logger.LogError(
                    LoggingBehaviorResource.LanguageResources.UnhandledExceptionLog,
                    actionGuid, DateTime.Now, ex.GetType().Name, typeof(TRequest).Name, ex.Message);

                throw;
            }
            finally
            {
                var endedDate = DateTime.Now;

                var state = success ? LoggingBehaviorResource.LanguageResources.SuccessState : LoggingBehaviorResource.LanguageResources.FailureState;
                var logLevel = success ? LogLevel.Information : LogLevel.Warning;

                _Logger.Log(logLevel, LoggingBehaviorResource.LanguageResources.FinalLog,
                    actionGuid, endedDate, typeof(TRequest).Name, state);
            }
        }
    }
}
