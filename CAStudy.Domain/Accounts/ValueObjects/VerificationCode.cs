using CAStudy.Domain.Accounts.Errors;
using CAStudy.Domain.Accounts.Errors.Exceptions;
using CAStudy.Domain.Shared.Abstractions;

namespace CAStudy.Domain.Accounts.ValueObjects;

public class VerificationCode
{
     private const int MinLength = 6;
     public string Code { get; } = string.Empty;
     public DateTime? ExpiresAtUtc { get; private set; }
     public DateTime? VerifiedAtUtc { get; private set; }
     public bool IsActive => !IsExpired && VerifiedAtUtc.HasValue;
     public bool IsExpired => ExpiresAtUtc is not null && ExpiresAtUtc.Value <= DateTime.UtcNow;

    private VerificationCode()
    {
    }

    private VerificationCode(string code, DateTime expiresAtUtc)
    {
        Code = code;
        ExpiresAtUtc = expiresAtUtc;
    }

    public static VerificationCode Create(IDateTimeProvider dateTimeProvider)
    {
        return new VerificationCode(
            Guid.NewGuid().ToString("N")[..MinLength].ToUpper(),
            dateTimeProvider.UtcNow.AddMinutes(5));
    }

    public void Verify(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new VerificationCodeNullException(ErrorMessages.VerificationCode.NullOrEmpty);

        if (string.IsNullOrWhiteSpace(code))
            throw new VerificationCodeNullException(ErrorMessages.VerificationCode.NullOrWhiteSpace);

        if (code.Length != MinLength)
            throw new VerificationCodeLenghtException(ErrorMessages.VerificationCode.InvalidLenght);

        if (Code != code)
            throw new InvalidVerificationCodeException(ErrorMessages.VerificationCode.InvalidCode);

        if (IsActive)
            throw new InactiveVerificationCodeException(ErrorMessages.VerificationCode.AlreadyActive);

        if (IsExpired)
            throw new InactiveVerificationCodeException(ErrorMessages.VerificationCode.Expired);

        VerifiedAtUtc = DateTime.UtcNow;
        ExpiresAtUtc = null;
    }

    public static implicit operator string(VerificationCode verificationCode)
    {
        return verificationCode.ToString();
    }
    
    public override string ToString()
    {
        return Code;
    }
}