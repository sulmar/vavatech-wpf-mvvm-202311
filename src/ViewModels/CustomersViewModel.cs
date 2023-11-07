using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using System.Collections.ObjectModel;
using System.Net;

namespace ViewModels;


public class FakeCustomer
{
    public IEnumerable<Customer> Generate()
    {
        var address = new Address { City = "Szczecin" };

        return new List<Customer>
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Smith", ShippingAddress = address},
            new Customer { Id = 2, FirstName = "Kate", LastName = "Smith", ShippingAddress = address },
            new Customer { Id = 3, FirstName = "Bob", LastName = "Smith", ShippingAddress = address }
        };
    }
}

public class CustomersViewModel : BaseViewModel
{
    public IList<Customer> Customers { get; }

    public CustomersViewModel()
        : this(new InMemoryCustomerRepository(new FakeCustomer().Generate()))
    {

    }

    public CustomersViewModel(ICustomerRepository repository)
    {
        Customers = repository.GetAll().ToList();
    }
}
