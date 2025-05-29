﻿using CAStudy.Domain.Shared.Events.Abstractions;
using CAStudy.Domain.Shared.ValueObjects;

namespace CAStudy.Domain.Shared.Entities;

public abstract class Entity(Guid id, Tracker tracker) : IEquatable<Guid>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public Guid Id { get; } = id;
    public Tracker Tracker { get; } = tracker;

    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents;

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);

    public bool Equals(Guid id)
    {
        return Id == id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}