using Kidega.Core.DTO;
using Kidega.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.ServiceContracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllBooksAsync();
        Task<BookResponse> GetBookAsync(int id);
        Task<BookResponse> CreateBookAsync(BookAddRequest request);
        Task UpdateBookAsync(BookUpdateRequest request);
        Task DeleteBookAsync(int id);
    }
}
