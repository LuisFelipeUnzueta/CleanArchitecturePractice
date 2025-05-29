using CAStudy.Domain.Accounts.Errors;
using CAStudy.Domain.Accounts.Errors.Exceptions;
using CAStudy.Domain.Shared.ValueObjects;

namespace CAStudy.Domain.Accounts.ValueObjects;

public sealed record LockOut : ValueObject
{
    private const int MinLockOutReasonLength = 5;
    private const int MaxLockOutReasonLength = 50;
    public DateTime? LockOutEndUtc { get; }
    public string? LockOutReason { get; }

    private LockOut()
    {
    }

    private LockOut(DateTime lockOutEndUtc, string? lockOutReason)
    {
        LockOutEndUtc = lockOutEndUtc;
        LockOutReason = lockOutReason;
    }
    
    public static LockOut Create(int durationInMinutes, string? lockOutReason = null)
    {
        Validate(durationInMinutes, lockOutReason);
        return new LockOut(DateTime.UtcNow.AddMinutes(durationInMinutes), lockOutReason);
    }
    
    private static void Validate(int durationInMinutes, string? lockOutReason)
    {
        if (durationInMinutes <= 0)
            throw new InvalidLockOutExpiredException(ErrorMessages.LockOut.InvalidLockOutExpired);

        if (lockOutReason is not null)
        {
            if (lockOutReason.Length is < MinLockOutReasonLength or > MaxLockOutReasonLength)
                throw new InvalidLockOutReasonLengthException(ErrorMessages.LockOut.InvalidLockOutReasonLength);
        }
    }
}