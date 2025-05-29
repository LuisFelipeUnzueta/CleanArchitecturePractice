using CAStudy.Domain.Shared.Events.Abstractions;

namespace CAStudy.Domain.Accounts.Events;

public sealed record OnResendEmailVerificationEvent(Guid Id, string Name, string Email, 
    string VerificationCode) : IDomainEvent;