using Microsoft.AspNetCore.Mvc;
using WebAPI.BL.DTO;
using WebAPI.BL.DTO.Product;
using WebAPI.BL.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {
        public ProductService _productService { get; set; }

        public ProductController(ProductService productService) { 
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct([FromRoute] int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result is null)
                return NotFound(new ErrorResponse("Продукт не найден!"));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductRequest request)
        {
            var result = await _productService.CreateAsync(request);
            if (!result)
                return BadRequest(new ErrorResponse("Не удалось создать продукт. Проверьте правильное заполнение данных!"));

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductRequest request)
        {
            var result = await _productService.UpdateAsync(request);
            if (!result)
                return BadRequest(new ErrorResponse("Не удалось обновить продукт. Проверьте правильное заполнение данных!"));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
                return NotFound(new ErrorResponse("Продукт не найден!"));

            var result = await _productService.DeleteAsync(product);
            if (!result)
                return StatusCode(500, "Не удалось удалить продукт!");

            return Ok(result);
        }
    }
}
