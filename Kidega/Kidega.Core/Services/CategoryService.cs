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
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        public async Task<CategoryResponse> CreateCategoryAsync(CategoryAddRequest request)
        {
            var category = mapper.Map<Category>(request);
            await categoryRepository.Add(category);
            return mapper.Map<CategoryResponse>(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var categoryToDelete = await categoryRepository.Get(id);
            if(categoryToDelete == null)
            {
                throw new Exception("Category not found");
            }
            await categoryRepository.Remove(categoryToDelete);
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var categories = await categoryRepository.GetAll();
            return mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }

        public async Task<CategoryResponse> GetCategoryAsync(int id)
        {
            var category = await categoryRepository.Get(id);
            if(category == null)
            {
                throw new Exception("Category not found");
            }
            return mapper.Map<CategoryResponse>(category);
        }

        public async Task UpdateCategoryAsync(CategoryUpdateRequest request)
        {
            var categoryFromDb = await categoryRepository.Get(request.CategoryId);
            if(categoryFromDb == null)
            {
                throw new Exception("Category not found");
            }
            var categoryToUpdate = mapper.Map<Category>(request);
            await categoryRepository.Update(categoryToUpdate);
        }
    }
}
