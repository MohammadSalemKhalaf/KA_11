using KA_11.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KA_11.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T :BaseModel
    {
        int Add(T entity);
        IEnumerable<T> GetAll(bool withTracking = false);
        T? GetById(int id);
        int Update(T entity);
        int Remove(T entity);
    }
}
