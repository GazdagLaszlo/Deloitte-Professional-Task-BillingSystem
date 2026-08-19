using Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs;
using Deloitte_prof_task_Laszlo_Gazdag.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte_prof_task_Laszlo_Gazdag.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCreateDTO createDto)
        {
            var result = await productService.CreateProductAsync(createDto);
            return Ok(result);
        }
    }
}
