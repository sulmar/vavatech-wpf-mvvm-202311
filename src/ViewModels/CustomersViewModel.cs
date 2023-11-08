using Domain.Abstractions;
using Domain.Models;

namespace ViewModels;

public class CustomersViewModel : BaseViewModel
{
    public IList<Customer> Customers { get; }

    public CustomersViewModel(ICustomerRepository repository)
    {
        Customers = repository.GetAll().ToList();
    }
}
