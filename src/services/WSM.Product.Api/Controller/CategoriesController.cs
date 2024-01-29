using Microsoft.AspNetCore.Mvc;
using WSM.Catalog.Api.Services;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get([FromQuery] GetCategory category) 
        {
            var categorieslist = await _categoryServices.GetCategoriesAsync(category);
            if(categorieslist is null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categorieslist);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetProducts(CategoryViewModel categoryViewModel)
        {
            var categorieslist = await _categoryServices.GetAllCategoriesProductsAsync();
            if (categorieslist is null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categorieslist);
        }

        [HttpGet("{id:int}", Name ="GetCategory")]
        public async Task<ActionResult<CategoryViewModel>> Get(int id)
        {
            var categories = await _categoryServices.GetCategoryByIdAsync(id);
            if (categories is null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categories);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Post([FromBody] CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel is null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryServices.AddCategory(categoryViewModel);

            //retorna atraves da action a categoria criada
            return new CreatedAtRouteResult("GetCategory", new { id = categoryViewModel.CategoryId }, categoryViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel is null || categoryViewModel.CategoryId != id)
            {
                return BadRequest();
            }

            await _categoryServices.UpdateCategory(categoryViewModel);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryViewModel>> Delete(int id)
        {
            var categoryViewModel = await _categoryServices.GetCategoryByIdAsync(id);
            if (categoryViewModel is null)
            {
                return NotFound("Category not found");
            }

            await _categoryServices.RemoveCategory(id);

            return Ok(categoryViewModel);
        }


    }
}
