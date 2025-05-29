using CAStudy.Domain.Accounts.Errors.Exceptions;
using CAStudy.Domain.Shared.Abstractions;

namespace CAStudy.Domain.Shared.ValueObjects;

public sealed record Tracker : ValueObject
{
    public DateTime CreatedAtUtc { get; }
    public DateTime UpdatedAtUtc { get; private set; }

    private Tracker()
    {
    }

    private Tracker(DateTime createdAtUtc, DateTime cpdatedAtUtc)
    {
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = cpdatedAtUtc;
    }

    public static Tracker Create()
        => new(DateTime.UtcNow, DateTime.UtcNow);

    public static Tracker Create(IDateTimeProvider dateTimeProvider)
        => new(dateTimeProvider.UtcNow, dateTimeProvider.UtcNow);

    public void Update(IDateTimeProvider dateTimeProvider)
    {
        if (dateTimeProvider.UtcNow < CreatedAtUtc)
            throw new InvalidDateTimeProviderIsExpired("");
        
        UpdatedAtUtc = dateTimeProvider.UtcNow;
    }
}