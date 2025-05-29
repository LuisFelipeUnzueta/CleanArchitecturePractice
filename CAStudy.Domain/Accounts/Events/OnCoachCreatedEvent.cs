using CAStudy.Domain.Shared.Events.Abstractions;

namespace CAStudy.Domain.Accounts.Events;

public class OnCoachCreatedEvent(Guid Id, string Name, string Email) : IDomainEvent;