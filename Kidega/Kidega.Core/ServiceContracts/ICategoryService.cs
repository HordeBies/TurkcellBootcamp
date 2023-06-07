using Kidega.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.ServiceContracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        Task<CategoryResponse> GetCategoryAsync(int id);
        Task<CategoryResponse> CreateCategoryAsync(CategoryAddRequest request);
        Task UpdateCategoryAsync(CategoryUpdateRequest request);
        Task DeleteCategoryAsync(int id);
    }
}
