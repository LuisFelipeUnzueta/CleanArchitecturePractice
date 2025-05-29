using CAStudy.Domain.Shared.Exceptions;

namespace CAStudy.Domain.Accounts.Errors.Exceptions;

public class VerificationCodeLenghtException(string message) : DomainException(message);