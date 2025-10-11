using KA_11.DAL.Models;

namespace KA_11.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //this interface can be extended with category-specific methods if needed
        //for now, it inherits all CRUD operations from IGenericRepository
        // Example of a category-specific method:
        // IEnumerable<Category> GetActiveCategories();

    }
}