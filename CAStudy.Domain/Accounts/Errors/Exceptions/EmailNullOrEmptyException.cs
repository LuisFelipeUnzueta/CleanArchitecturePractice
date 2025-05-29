using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class EmailNullOrEmptyException(string message) : DomainException(message);