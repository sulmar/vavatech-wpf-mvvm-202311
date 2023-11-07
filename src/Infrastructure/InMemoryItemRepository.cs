using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class InMemoryItemRepository : InMemoryEntityRepository<Item>, IItemRepository
{
    public InMemoryItemRepository(IEnumerable<Item> items) : base(items)
    {
    }
}
