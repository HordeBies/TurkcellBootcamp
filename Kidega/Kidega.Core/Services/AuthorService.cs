using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Domain.Entities;
using Kidega.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.Services
{
    public class AuthorService(IAuthorRepository authorRepository, IMapper mapper) : IAuthorService
    {
        public async Task<AuthorResponse> CreateAuthorAsync(AuthorAddRequest request)
        {
            var author = mapper.Map<Author>(request);
            await authorRepository.Add(author);
            return mapper.Map<AuthorResponse>(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var authorToDelete = await authorRepository.Get(id);
            if(authorToDelete == null)
            {
                throw new Exception("Author not found");
            }
            await authorRepository.Remove(authorToDelete);
        }

        public async Task<IEnumerable<AuthorResponse>> GetAllAuthorsAsync()
        {
            var authors = await authorRepository.GetAll();
            return mapper.Map<IEnumerable<AuthorResponse>>(authors);
        }

        public async Task<AuthorResponse> GetAuthorAsync(int id)
        {
            var author = await authorRepository.Get(id);
            if(author == null)
            {
                throw new Exception("Author not found");
            }
            return mapper.Map<AuthorResponse>(author);
        }

        public async Task UpdateAuthorAsync(AuthorUpdateRequest request)
        {
            var authorFromDb = await authorRepository.Get(request.Id);
            if(authorFromDb == null)
            {
                throw new Exception("Author not found");
            }
            var authorToUpdate = mapper.Map<Author>(request);
            await authorRepository.Update(authorToUpdate);
        }
    }
}
