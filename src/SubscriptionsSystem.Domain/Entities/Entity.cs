namespace SubscriptionsSystem.Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    protected Entity(int id) => Id = id;
    public int Id { get; }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj.GetType() != GetType()) return false;
        if (obj is not Entity entity) return false;

        return Id == entity.Id;
    }

    public override int GetHashCode()
        => Id ^ 431;

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (other.GetType() != GetType()) return false;
        if (ReferenceEquals(this, other)) return true;
        return other.Id == Id;
    }

    public static bool operator ==(Entity? left, Entity? right)
        => left is not null && right is not null && left.Equals(right);

    public static bool operator !=(Entity? left, Entity? right) => !(left == right);
}