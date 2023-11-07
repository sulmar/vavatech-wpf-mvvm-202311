using CommunityToolkit.Mvvm.Input;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;
using System.Windows.Input;

namespace ViewModels;

public class ItemsViewModel : BaseViewModel
{
    public IList<Item> Items { get; }

    public Item SelectedItem { get; set; }

    public ItemsViewModel()
        : this(new InMemoryItemRepository(
            new ProductFaker().Generate(50).Cast<Item>()
            .Union(new ServiceFaker().Generate(10))
            ))
    {
    }

    public ItemsViewModel(IItemRepository repository)
    {
        Items = repository.GetAll().ToList();


    }

    public ICommand DiscountPriceCommand => new RelayCommand(DiscountPrice);

    public void DiscountPrice()
    {
        SelectedItem.Price -= 1;
    }
}