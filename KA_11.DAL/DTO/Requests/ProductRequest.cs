using KA_11.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.DTO.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        //img as image file  
        public IFormFile mainImage { get; set; }
        public double Rate { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
