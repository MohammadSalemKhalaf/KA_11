using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using KA_11.DAL.Models;
using KA_11.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Classes
{
    public class ProductService : GenericService<ProductRequest, ProductResponse, Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepository ProductRepository,IFileService fileService) :base(ProductRepository)
        {
            _productRepository = ProductRepository;
            _fileService = fileService;
        }
        public async Task<int> CreateFile(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.createdAt = DateTime.UtcNow;
            if (request.mainImage != null)
            {
                var imagePath = await _fileService.UploadImageAsync(request.mainImage);
                entity.mainImage = imagePath;
            }
            return _productRepository.Add(entity);
        }
    }
}
