using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Interfaces
{
    public interface ICartService
    {
         bool AddToCart(string userId, CartRequest request);
         CartSummaryResponse GetCartSummary(string userId);

    }
}
