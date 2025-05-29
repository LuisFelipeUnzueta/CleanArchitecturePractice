using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class InvalidCpfNumberException(string message) : DomainException(message);