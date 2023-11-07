using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels;

public partial class ItemsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<Item> items;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(DiscountPriceCommand))]
    private Item selectedItem;

    public ItemsViewModel()
        : this(new InMemoryItemRepository(
            new ProductFaker().Generate(50).Cast<Item>()
            .Union(new ServiceFaker().Generate(10))
            ))
    {
    }

    public ItemsViewModel(IItemRepository repository)
    {
        Items = new ObservableCollection<Item>(repository.GetAll());
    }

    [RelayCommand(CanExecute = nameof(CanDiscountPrice))]
    private void DiscountPrice()
    {
        SelectedItem.Price -= 1;
    }

    private bool CanDiscountPrice()
    {
        return SelectedItem?.Price > 100;
    }
}