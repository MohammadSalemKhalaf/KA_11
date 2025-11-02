using Azure.Core;
using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KA_11.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
            var result =await _ProductService.CreateFile(request);
            return Ok(result);
        }
    }

    }
