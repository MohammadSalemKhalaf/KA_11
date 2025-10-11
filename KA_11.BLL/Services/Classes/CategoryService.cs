using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using KA_11.DAL.Models;
using KA_11.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }
        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
          return  _categoryRepository.Add(category);
        }

        public int DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null) return 0;
            return _categoryRepository.Remove(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var catogories = _categoryRepository.GetAll();
            return catogories.Adapt<IEnumerable<CategoryResponse>>();
        }

        public CategoryResponse? GetCategoryById(int id)
        {
            var category=_categoryRepository.GetById(id);
            return category == null ? null : category.Adapt<CategoryResponse>();
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category= _categoryRepository.GetById(id);
            if(category == null) return 0;
            category.Name = request.Name;
            return _categoryRepository.Update(category);

        }
        public bool ToggleStatus(int id) {
            var category = _categoryRepository.GetById(id);
            if (category == null) return false;
            category.status = category.status == Status.Active ? Status.Inactive : Status.Active;
            _categoryRepository.Update(category);
            return true;

        }
    }
}
