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

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return;

        Name = name;
    }

    public void ChangePrice(decimal monthlyPrice, decimal yearlyPrice)
    {
        if (monthlyPrice <= 0 || yearlyPrice <= 0)
            return;

        MonthlyPrice = monthlyPrice;
        YearlyPrice = yearlyPrice;
    }

    #region Features

    public void AddFeature(string name, string? description)
    {
        if (_features.Any(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            return;

        var feature = Feature.Create(name, description);
        _features.Add(feature);
    }

    public void RemoveFeature(string name)
    {
        var feature = _features.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (feature is null)
            return;

        _features.Remove(feature);
    }

    public void RemoveFeature(int id)
    {
        var feature = _features.FirstOrDefault(f => f.Id == id);
        if (feature is null)
            return;

        _features.Remove(feature);
    }

    public void UpdateFeatures(IReadOnlyCollection<(string name, string? description)> features)
    {
        if (!features.Any())
            return;

        _features.Clear();

        foreach (var feature in features)
            AddFeature(feature.name, feature.description);
    }

    #endregion
}