using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class CpfNullOrEmptyException(string message) : DomainException(message);