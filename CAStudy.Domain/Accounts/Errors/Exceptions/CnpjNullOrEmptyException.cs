using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class CnpjNullOrEmptyException(string message) : DomainException(message);