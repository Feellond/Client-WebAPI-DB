using Microsoft.AspNetCore.Mvc;
using WebAPI.BL.DTO.Product;
using WebAPI.BL.DTO;
using WebAPI.BL.Services;
using WebAPI.BL.DTO.Manufacturer;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/manufacturer")]
    public class ManufacturerController : ControllerBase
    {
        public ManufacturerService _manufacturerService { get; set; }

        public ManufacturerController(ManufacturerService manufacturerService) 
        { 
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllManufacturers()
        {
            var result = await _manufacturerService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetManufacturer([FromRoute] int id)
        {
            var result = await _manufacturerService.GetByIdAsync(id);
            if (result is null)
                return NotFound(new ErrorResponse("Производитель не найден!"));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateManufacturer(ManufacturerRequest request)
        {
            var result = await _manufacturerService.CreateAsync(request);
            if (!result)
                return BadRequest(new ErrorResponse("Не удалось создать производителя. Проверьте правильное заполнение данных!"));

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateManufacturer(ManufacturerRequest request)
        {
            var result = await _manufacturerService.UpdateAsync(request);
            if (!result)
                return BadRequest(new ErrorResponse("Не удалось обновить производителя. Проверьте правильное заполнение данных!"));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManufacturer([FromRoute] int id)
        {
            var product = await _manufacturerService.GetByIdAsync(id);
            if (product is null)
                return NotFound(new ErrorResponse("Производитель не найден!"));

            var result = await _manufacturerService.DeleteAsync(product);
            if (!result)
                return StatusCode(500, "Не удалось удалить производителя!");

            return Ok(result);
        }
    }
}
