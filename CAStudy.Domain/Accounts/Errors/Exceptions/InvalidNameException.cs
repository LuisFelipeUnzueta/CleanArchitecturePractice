using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class InvalidNameException(string message) : DomainException(message);