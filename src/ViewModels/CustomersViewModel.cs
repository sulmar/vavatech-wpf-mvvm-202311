using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;
using System.Collections.ObjectModel;
using System.Net;

namespace ViewModels;

public class CustomersViewModel : BaseViewModel
{
    public IList<Customer> Customers { get; }

    public CustomersViewModel()
        : this(new InMemoryCustomerRepository(new CustomerFaker().Generate(100)))
    {
        
    }

    public CustomersViewModel(ICustomerRepository repository)
    {
        Customers = repository.GetAll().ToList();
    }
}
