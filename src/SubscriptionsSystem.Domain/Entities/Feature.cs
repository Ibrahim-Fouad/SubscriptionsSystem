namespace SubscriptionsSystem.Domain.Entities;

public class Feature : Entity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    private Feature(int id, string name, string? description) : base(id)
    {
        Name = name;
        Description = description;
    }

    internal static Feature Create(string name, string? description)
    {
        return new Feature(0, name, description);
    }
}