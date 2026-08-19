using Deloitte_prof_task_Laszlo_Gazdag.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InvoiceController(IInvoiceService invoiceService) : ControllerBase
    {
        [HttpGet("{id}/invoice")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            try
            {
                var invoiceText = await invoiceService.GenerateInvoiceAsync(id);
                var bytes = Encoding.UTF8.GetBytes(invoiceText);

                return File(bytes, "text/html", $"invoice_order_{id}.html");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
