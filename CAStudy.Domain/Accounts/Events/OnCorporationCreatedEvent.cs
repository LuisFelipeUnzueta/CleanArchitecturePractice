using CAStudy.Domain.Shared.Events.Abstractions;

namespace CAStudy.Domain.Accounts.Events;

public sealed record OnCorporationCreatedEvent(Guid Id, string Name, string Email) : IDomainEvent;