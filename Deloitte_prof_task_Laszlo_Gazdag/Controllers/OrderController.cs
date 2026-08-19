using Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs;
using Deloitte_prof_task_Laszlo_Gazdag.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte_prof_task_Laszlo_Gazdag.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<OrderDTO>(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] OrderCreateDTO createDto)
        {
            var result = await orderService.CreateOrderAsync(createDto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType<IList<OrderDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await orderService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType<OrderDetailedDTO>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await orderService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
