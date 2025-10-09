using KA_11.DAL.Models;

namespace KA_11.DAL.Repositories
{
    public interface ICategoryRepository
    {
        int Add(Category category);
        IEnumerable<Category> GetAll(bool withTracking=false);
        Category? GetById(int id);
        int Update(Category category);
        int Remove(Category category);


    }
}