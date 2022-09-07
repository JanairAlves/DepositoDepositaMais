using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var categories = _categoryService.GetAll(query);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);

            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewCategoryInputModel inputModel)
        {
            if(inputModel.CategoryName.Length > 50)
                return BadRequest();

            var id = _categoryService.CreateNewCategory(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
                return BadRequest();

            _categoryService.UpdateCategory(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}/inactivate")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }

        [HttpPut("{id}/activate")]
        public IActionResult Activate(int id)
        {
            _categoryService.ActivateCategory(id);
            return NoContent();
        }
    }
}
