using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;

namespace ViewModels;

public class ItemsViewModel : BaseViewModel
{
    public IList<Item> Items { get; }

    public ItemsViewModel()
        : this(new InMemoryItemRepository(
            new ProductFaker().Generate(10).Cast<Item>()
            .Union(new ServiceFaker().Generate(10))
            ))
    {
    }

    public ItemsViewModel(IItemRepository repository)
    {
        Items = repository.GetAll().ToList();
    }
}