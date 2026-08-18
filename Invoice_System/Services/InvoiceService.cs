using Invoice_System.Data;
using Invoice_System.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Invoice_System.Services
{
    public class InvoiceService
    {
        private AppDbContext _context;
        public InvoiceService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<InvoiceResponseDto?> GenerateInvoiceAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
            if(order == null)
            {
                return null;
            }

            var invoice = new InvoiceResponseDto
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
            };

            foreach(var item in order.Items)
            {

                var lineTotal = item.UnitPriceAtOrder * item.Quantity;
                if (item.Product.IsDiscountEligible)
                {
                    lineTotal *= (1 - item.Product.Discount / 100);
                }
                var line = new InvoiceLineDto
                {
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPriceAtOrder,
                    Discount = item.Product.Discount,
                    IsFragile = item.Product.IsFragile,
                    LineTotal = lineTotal,
                };
                invoice.Lines.Add(line);
            }
            invoice.TotalAmount = invoice.Lines.Sum(line => line.LineTotal);
            return invoice;
        }
    }
}
