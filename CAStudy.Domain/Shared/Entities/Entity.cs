namespace CAStudy.Domain.Shared.Entities;

public abstract class Entity(Guid? id) : IEquatable<Guid>
{
    public Guid Id { get; } = id ?? Guid.NewGuid();

    public bool Equals(Guid id) => Id == id;


    public override int GetHashCode() => Id.GetHashCode();
    
}