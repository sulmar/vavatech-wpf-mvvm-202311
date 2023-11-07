using Domain.Models;
using System.Collections.ObjectModel;

namespace ViewModels;

public class CustomersViewModel : BaseViewModel
{
    public IList<Customer> Customers { get; }

    public CustomersViewModel()
    {
        var address = new Address { City = "Szczecin" };

        Customers = new List<Customer>
        {
            new Customer { FirstName = "John", LastName = "Smith", ShippingAddress = address},
            new Customer { FirstName = "Kate", LastName = "Smith", ShippingAddress = address },
            new Customer { FirstName = "Bob", LastName = "Smith", ShippingAddress = address }
        };
    }
}
