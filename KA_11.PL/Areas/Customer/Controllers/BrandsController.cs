using KA_11.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KA_11.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles="Customer")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_BrandService.GetAll(true) );
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Brand = _BrandService.GetById(id);
            if (Brand is null) return NotFound();
            return Ok(Brand);
        }
    }
}
