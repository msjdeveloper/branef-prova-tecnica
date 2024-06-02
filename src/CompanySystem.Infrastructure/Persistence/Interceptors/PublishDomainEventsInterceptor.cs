using CompanySystem.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CompanySystem.Infrastructure.Persistence.Interceptors
{
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator; // MediatR IPublisher

        public PublishDomainEventsInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }

        override public InterceptionResult<int> SavingChanges(
                       DbContextEventData eventData,
                       InterceptionResult<int> result)
        {
            // Publish domain events
            PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
                       DbContextEventData eventData,
                       InterceptionResult<int> result,
                       CancellationToken cancellationToken = default)
        {
            // Publish domain events
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainEvents(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }

            var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(x => x.Entity.DomainEvents.Any())
                .Select(x => x.Entity)
                .ToList();

            var domainEvents = entitiesWithDomainEvents
                .SelectMany(x => x.DomainEvents)
                .ToList();

            // Important to clear domain events before publishing them! To avoid recursive publishing
            entitiesWithDomainEvents.ForEach(x => x.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}
