using KA_11.DAL.DTO.Requests;
using KA_11.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
         public int Add(Cart cart);
        List<Cart> GetCartItemsByUserId(string userId);
    }
}
