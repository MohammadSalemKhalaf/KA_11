using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        //img as string
        public string mainImage { get; set; }
        public double Rate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
