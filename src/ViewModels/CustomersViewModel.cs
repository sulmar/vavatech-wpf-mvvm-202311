using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Abstractions;
using Domain.Models;
using System.Collections.ObjectModel;

namespace ViewModels;

public partial class CustomersViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Customer> customers;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SendCommand))]
    [NotifyCanExecuteChangedFor(nameof(PrintCommand))]
    private Customer selectedCustomer;

    private readonly IEnumerable<IMessageService> messageServices;

    public CustomersViewModel()
    {    
    }

    public CustomersViewModel(ICustomerRepository repository, IEnumerable<IMessageService> messageServices)
    {
        Customers = new ObservableCollection<Customer>(repository.GetAll());
        this.messageServices = messageServices;
    }

    [RelayCommand(CanExecute =nameof(CanSend))]
    void Send()
    {
        var message = new Message(
            $"Send message to {SelectedCustomer.Email}", 
            "Message", 
            SelectedCustomer.Email, true);

        foreach(var messageService in messageServices)
        {
            messageService.Send(message);
        }
    }

    [RelayCommand(CanExecute = nameof(CanPrint))]
    void Print()
    {
        Console.WriteLine($"Print {SelectedCustomer.FullName}");
    }

    bool CanPrint => isSelectedCustomer && SelectedCustomer.FirstName.Length > 5;

    private bool isSelectedCustomer => SelectedCustomer != null;

    bool CanSend => isSelectedCustomer;
}
