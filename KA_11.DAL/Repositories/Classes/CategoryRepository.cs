using KA_11.DAL.Data;
using KA_11.DAL.Models;
using KA_11.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.Repositories.Classes
{
    public class CategoryRepository :GenericRepository<Category> ,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
        }

    }
}
