using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class InvalidDateTimeProviderIsExpired(string message) : DomainException(message);