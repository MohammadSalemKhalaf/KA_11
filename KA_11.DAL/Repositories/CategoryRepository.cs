using KA_11.DAL.Data;
using KA_11.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }


        public IEnumerable<Category> GetAll(bool withTracking = false)
        {
            return   withTracking ? _context.Categories.ToList() : _context.Categories.AsNoTracking().ToList();
        }

        public Category? GetById(int id) => _context.Categories.Find(id);


        public int Remove(Category category)
        {
            _context.Categories.Remove(category);
            return _context.SaveChanges();
        }

        public int Update(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChanges();
        }
    }
}
