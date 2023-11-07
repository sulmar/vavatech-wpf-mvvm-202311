using Bogus;
using Domain.Models;

namespace Infrastructure.Fakers;

public class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));
        RuleFor(p => p.Color, f => f.Commerce.Color());
        RuleFor(p => p.Weight, f => f.Random.Float(100, 500));
    }
}
