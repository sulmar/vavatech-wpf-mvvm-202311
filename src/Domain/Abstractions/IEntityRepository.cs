using Domain.Models;

namespace Domain.Abstractions;

public interface IEntityRepository<T>
    where T : BaseEntity
{
    IEnumerable<T> GetAll();
}
