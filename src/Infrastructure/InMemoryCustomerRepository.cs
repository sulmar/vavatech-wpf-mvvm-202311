using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly IDictionary<int, Customer> customers;

    public InMemoryCustomerRepository(IEnumerable<Customer> customers)
    {
        this.customers = customers.ToDictionary(p => p.Id);
    }

    public IEnumerable<Customer> GetAll()
    {
        return customers.Values.ToList();
    }
}