using CommunityToolkit.Mvvm.Input;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels;

public partial class ShellViewModel : BaseViewModel
{
    private readonly INavigationService navigation;

    public ShellViewModel(INavigationService navigation)
    {
        this.navigation = navigation;
    }

    [RelayCommand]
    void NavigateToCustomers()
    {
        navigation.NavigateTo("Customers");
        // navigation.NavigateTo("Views/CustomersView.xaml");
    }

    [RelayCommand]
    void NavigateToItems()
    {
        navigation.NavigateTo("Items");
       // navigation.NavigateTo("Views/ItemsView.xaml");
    }
}
