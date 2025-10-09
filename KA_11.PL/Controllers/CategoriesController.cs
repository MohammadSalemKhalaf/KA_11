using Azure.Core;
using KA_11.BLL.Services;
using KA_11.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KA_11.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

                private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var category= _categoryService.GetCategoryById(id);
            if(category is null) return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Create([FromBody]CategoryRequest request)
        {
            var id = _categoryService.CreateCategory(request);
           return CreatedAtAction(nameof(GetById),new {id});
        }
        [HttpPatch("{id}")]
        public IActionResult Update( [FromRoute] int id , [FromBody] CategoryRequest request)
        {
            var rows = _categoryService.UpdateCategory(id, request);
            if (rows == 0) return NotFound();
            return Ok();
        }
        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var response = _categoryService.ToggleStatus(id);
            return response ? Ok(new {message="Status Toggled"}) : NotFound(new {message="Category not found"});
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var rows = _categoryService.DeleteCategory(id);
            if (rows == 0) return NotFound();
            return Ok(new {message="Category was deleted succesfully"});
        }
    }
}
