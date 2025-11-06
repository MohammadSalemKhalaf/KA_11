using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using KA_11.DAL.Models;
using KA_11.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Classes
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository CartRepository)
        {
            _cartRepository = CartRepository;
        }
        public bool AddToCart(string userId, CartRequest request)
        {
            var newItem = new Cart
            {
                UserId = userId,
                ProductId = request.ProductId,
                Count = 1
            };
            return _cartRepository.Add(newItem) > 0;
        }
        public CartSummaryResponse GetCartSummary(string userId)
        {
            var cartItems = _cartRepository.GetCartItemsByUserId(userId);
            var response = new CartSummaryResponse
            {
                Items = cartItems.Select(ci => new CartResponse
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Price = ci.Product.Price,
                    Count = ci.Count
                }).ToList()
            };
            return response;
        }
    }
}
