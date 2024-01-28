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

        [HttpGet("buscar-todas")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get(CategoryViewModel categoryViewModel) 
        {
            var categorieslist = await _categoryServices.GetCategoriesAsync(categoryViewModel);
            if(categorieslist is null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categorieslist);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get(CategoryViewModel categoryViewModel)
        {
            var categorieslist = await _categoryServices.GetAllCategoriesProductsAsync();
            if (categorieslist is null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categorieslist);
        }


    }
}
