using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public abstract class InMemoryEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{ 
    private readonly IDictionary<int, T> items;

    public InMemoryEntityRepository(IEnumerable<T> items)
    {
        this.items = items.ToDictionary(p => p.Id);
    }

    public IEnumerable<T> GetAll()
    {
        return items.Values.ToList();
    }
}