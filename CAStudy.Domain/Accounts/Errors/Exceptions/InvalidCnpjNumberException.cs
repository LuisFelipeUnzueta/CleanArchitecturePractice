using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class InvalidCnpjNumberException(string message) : DomainException(message);