namespace SubscriptionsSystem.Domain.Entities;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();


    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEquals(other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != GetType()) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj is ValueObject valueObject && ValuesAreEquals(valueObject);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(default(int), HashCode.Combine);
    }

    private bool ValuesAreEquals(ValueObject? other)
    {
        if (other is null) return false;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }
}