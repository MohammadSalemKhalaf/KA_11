using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KA_11.DAL.Models;
namespace KA_11.BLL.Services.Interfaces
{
    public interface IProductService : IGenericService<ProductRequest, ProductResponse,Product>
    {
        public Task<int> CreateFile(ProductRequest request);

    }
}
