using Kidega.Domain.Entities;
using System.Linq.Expressions;

namespace Kidega.Domain.RepositoryContracts
{
    public interface IRepository<T> where T : class,IEntity
    {
        Task<IEnumerable<T>> GetAll(string? includeProperties = null, bool tracked = false);
        Task<T?> Get(int id, string? includeProperties = null, bool tracked = false);
        Task Add(T entity);
        Task Remove(T entity);
        Task Update(T entity);
    }
}
