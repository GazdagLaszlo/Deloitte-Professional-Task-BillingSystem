using System.Text;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Context;
using Microsoft.EntityFrameworkCore;

namespace Deloitte_prof_task_Laszlo_Gazdag.Services
{
    public interface IInvoiceService
    {
        Task<string> GenerateInvoiceAsync(int orderId);
    }

    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;

        public InvoiceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateInvoiceAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order is null)
                throw new KeyNotFoundException($"Order with id - {orderId} not found");

            var sb = new StringBuilder();
            decimal total = 0;

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang='en'>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset='UTF-8'>");
            sb.AppendLine($"<title>Invoice #{order.Id}</title>");
            sb.AppendLine("<style>body { font-family: monospace; } table { border-collapse: collapse; } td, th { padding: 4px 10px; text-align: left; }</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");

            sb.AppendLine("<h2>INVOICE</h2>");

            sb.AppendLine($"<p>Customer: {order.Customer.Name}<br>");
            sb.AppendLine($"Date: {order.OrderDate:yyyy-MM-dd}</p>");

            sb.AppendLine("<table border='1'>");
            sb.AppendLine("<tr><th>Item</th><th>Quantity</th><th>Price</th><th>Item Total</th></tr>");

            foreach (var item in order.OrderItems)
            {
                var itemTotal = item.Quantity * item.UnitPrice;
                total += itemTotal;

                var tags = new List<string>();
                if (item.Product.IsDiscountEligible)
                    tags.Add("Discount");
                if (item.Product.IsFragile)
                    tags.Add("Fragile");

                var productName = tags.Any()
                    ? $"{item.Product.Name} [{string.Join(", ", tags)}]"
                    : item.Product.Name;

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td>{productName}</td>");
                sb.AppendLine($"<td>{item.Quantity}</td>");
                sb.AppendLine($"<td>{item.UnitPrice}</td>");
                sb.AppendLine($"<td>{itemTotal}</td>");
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");

            sb.AppendLine($"<p><b>TOTAL: {total}</b></p>");

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}