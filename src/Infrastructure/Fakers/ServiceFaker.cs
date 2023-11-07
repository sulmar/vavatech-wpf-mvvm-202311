using Bogus;
using Domain.Models;

namespace Infrastructure.Fakers;

public class ServiceFaker : Faker<Service>
{
    public ServiceFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker + 100);
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));
        RuleFor(p => p.Duration, f => TimeSpan.FromMinutes(f.Random.Double(30, 60)));
    }
}
