using Azure.Core;
using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KA_11.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        [HttpGet("")]
        public IActionResult GetAllCategories()
        {
            return Ok(_BrandService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Brand = _BrandService.GetById(id);
            if (Brand is null) return NotFound();
            return Ok(Brand);
        }
        [HttpPost]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = _BrandService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id });
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var rows = _BrandService.Update(id, request);
            if (rows == 0) return NotFound();
            return Ok();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var response = _BrandService.ToggleStatus(id);
            return response ? Ok(new { message = "Status Toggled" }) : NotFound(new { message = "Brand not found" });
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var rows = _BrandService.Delete(id);
            if (rows == 0) return NotFound();
            return Ok(new { message = "Brand was deleted succesfully" });
        }
    }
}
