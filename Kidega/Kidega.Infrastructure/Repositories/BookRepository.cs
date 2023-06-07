using Kidega.Domain.Entities;
using Kidega.Domain.RepositoryContracts;
using Kidega.Infrastructure.DatabaseContexts;

namespace Kidega.Infrastructure.Repositories
{
    public class BookRepository(ApplicationDbContext db) : Repository<Book>(db), IBookRepository
    {
    }
}
