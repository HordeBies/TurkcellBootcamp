using Kidega.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.ServiceContracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponse>> GetAllAuthorsAsync();
        Task<AuthorResponse> GetAuthorAsync(int id);
        Task<AuthorResponse> CreateAuthorAsync(AuthorAddRequest request);
        Task UpdateAuthorAsync(AuthorUpdateRequest request);
        Task DeleteAuthorAsync(int id);
    }
}
