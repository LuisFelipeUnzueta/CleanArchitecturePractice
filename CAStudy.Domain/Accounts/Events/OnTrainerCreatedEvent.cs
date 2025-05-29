using CAStudy.Domain.Shared.Events.Abstractions;

namespace CAStudy.Domain.Accounts.Events;

public sealed record OnTrainerCreatedEvent(Guid Id, string Name, string Email) : IDomainEvent;