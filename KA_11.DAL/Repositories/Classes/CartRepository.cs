using KA_11.DAL.Data;
using KA_11.DAL.DTO.Requests;
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
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Cart cart)
        {
            if (cart == null) throw new Exception("Cart item is null");
            _context.Cart.Add(cart);
            return _context.SaveChanges();
        }

        public List<Cart> GetCartItemsByUserId(string userId)
        {
            return _context.Cart.Include(c=>c.Product).Where(c=> c.UserId == userId).ToList();
        }
    }
}
