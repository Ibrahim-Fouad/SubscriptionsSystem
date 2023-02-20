namespace SubscriptionsSystem.Domain.Entities;

public class Product : AggregateRoot
{
    public string Name { get; private set; }
    public decimal MonthlyPrice { get; private set; }
    public decimal YearlyPrice { get; private set; }

    private readonly List<Feature> _features;

    public IReadOnlyCollection<Feature> Features => _features.AsReadOnly();

    private Product(int id, string name, decimal monthlyPrice, decimal yearlyPrice) : base(id)
    {
        Name = name;
        MonthlyPrice = monthlyPrice;
        YearlyPrice = yearlyPrice;
        _features = new();
    }

    public static Product Create(string name, decimal monthlyPrice, decimal yearlyPrice)
    {
        return new Product(0, name, monthlyPrice, yearlyPrice);
    }

    public void AddFeature(string name, string? description)
    {
        if (_features.Any(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            return;

        var feature = Feature.Create(name, description);
        _features.Add(feature);
    }
}