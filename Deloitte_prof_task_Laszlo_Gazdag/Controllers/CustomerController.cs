using Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs;
using Deloitte_prof_task_Laszlo_Gazdag.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deloitte_prof_task_Laszlo_Gazdag.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {         
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerCreateDTO createDto)
        {
            var result = await customerService.CreateCustomerAsync(createDto);
            return Ok(result);
        }
    }
}
