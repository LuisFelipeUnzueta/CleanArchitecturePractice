using CAStudy.Domain.Shared.Aggregates.Abstractions;

namespace CAStudy.Domain.Shared.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : IAggregateRoot;