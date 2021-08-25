using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Domain.Interfaces.Abstracts;

namespace SharedKernel.Infraestructure.EntityFramework.Interceptors
{
    public class EventInvokerInterceptor : SaveChangesInterceptor
    {
        private readonly IMediator _Mediator;

        public EventInvokerInterceptor(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var aggregateRoots = eventData.Context
                .ChangeTracker.Entries()
                .Where(e => e.Entity is IAggregateRoot)
                .Where(e => e.Entity is not null)
                .Select(e => e.Entity as IAggregateRoot)
                .ToList();

            foreach (var aggregateRoot in aggregateRoots)
            {
                if (aggregateRoot is null) continue;

                aggregateRoot.ClearEvents();
            }

            var eventTransferObjects = aggregateRoots.SelectMany(e => e!.GetEvents())
                .ToList();

            foreach (var eventTransferObject in eventTransferObjects)
            {
                await _Mediator.Send(eventTransferObject, cancellationToken);
            }

            return result;
        }
    }
}
