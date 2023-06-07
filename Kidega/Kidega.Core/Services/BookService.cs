using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Domain.Entities;
using Kidega.Domain.RepositoryContracts;
using System.Linq.Expressions;

namespace Kidega.Core.Services
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        public async Task<BookResponse> CreateBookAsync(BookAddRequest request)
        {
            var book = mapper.Map<Book>(request);
            await bookRepository.Add(book);
            book = await bookRepository.Get(book.Id, "Author,Category");
            return mapper.Map<BookResponse>(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var bookToDelete = await bookRepository.Get(id);
            if(bookToDelete == null)
            {
                throw new Exception("Book not found");
            }
            await bookRepository.Remove(bookToDelete);
        }

        public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
        {
            var books = await bookRepository.GetAll("Author,Category");
            return mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<BookResponse> GetBookAsync(int id)
        {
            var book = await bookRepository.Get(id, "Author,Category");
            if(book == null)
            {
                throw new Exception("Book not found");
            }
            return mapper.Map<BookResponse>(book);
        }

        public async Task UpdateBookAsync(BookUpdateRequest request)
        {

            var bookFromDb = await bookRepository.Get(request.Id);
            if(bookFromDb == null)
            {
                throw new Exception("Book not found");
            }
            var bookToUpdate = mapper.Map<Book>(request);
            await bookRepository.Update(bookToUpdate);
        }
    }
}
