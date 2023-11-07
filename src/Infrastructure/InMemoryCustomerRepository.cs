using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class InMemoryCustomerRepository : InMemoryEntityRepository<Customer>, ICustomerRepository
{
    public InMemoryCustomerRepository(IEnumerable<Customer> items) : base(items)
    {
    }
}
