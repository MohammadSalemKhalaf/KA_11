using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryRequest request);
        IEnumerable<CategoryResponse> GetAllCategories();
        CategoryResponse? GetCategoryById(int id);
        int UpdateCategory(int id, CategoryRequest request);
        int DeleteCategory(int id);
        bool ToggleStatus(int id);
        

        }
    }
