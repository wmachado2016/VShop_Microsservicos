using Microsoft.AspNetCore.Mvc;
using WSM.Catalog.Api.Services;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Get([FromQuery] GetProduct getProduct)
        {
            var productlist = await _productService.GetProductsAsync(getProduct);
            if (productlist is null)
            {
                return NotFound("Products not found");
            }

            return Ok(productlist);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductViewModel>> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Post([FromBody] ProductViewModel productViewModel)
        {
            if (productViewModel is null)
            {
                return BadRequest("Invalid Data");
            }

            await _productService.AddProduct(productViewModel);

            //retorna atraves da action a produto criada
            return new CreatedAtRouteResult("GetProduct", new { id = productViewModel.Id }, productViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductViewModel productViewModel)
        {
            if (productViewModel is null || productViewModel.Id != id)
            {
                return BadRequest();
            }

            await _productService.UpdateProduct(productViewModel);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductViewModel>> Delete(int id)
        {
            var productViewModel = await _productService.GetProductByIdAsync(id);
            if (productViewModel is null)
            {
                return NotFound("Product not found");
            }

            await _productService.RemoveProduct(id);

            return Ok(productViewModel);
        }

    }
}
