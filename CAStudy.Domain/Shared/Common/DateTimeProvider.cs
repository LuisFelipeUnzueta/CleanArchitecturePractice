using CAStudy.Domain.Shared.Abstractions;

namespace CAStudy.Domain.Shared.Common;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get; } = DateTime.UtcNow;
}