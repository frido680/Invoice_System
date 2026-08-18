using Invoice_System.Data;
using Invoice_System.DTOs;
using Invoice_System.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoice_System.Services
{
    public class OrderServices
    {
        private readonly AppDbContext _context;
        public OrderServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var customer = await _context.Customers.FindAsync(dto.CustomerId);
            if (customer == null) throw new Exception("Customer not found");
            var requestedItems = dto.Items.GroupBy(a => a.ProductId).Select(group => new
            {
                productId = group.Key,
                Quantity = group.Sum(item => item.Quantity)
            })
            .ToList();//Amennyiben 2 ugyan olyan productot rendel a rendelt darab összeadódik így 1-ben van kezelve az egész
            var productIds = requestedItems.Select(items => items.productId).ToList();
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            if (products.Count != productIds.Count)
            {
                throw new Exception("One or more products were not found.");
            }
            var productsById = products.ToDictionary(product => product.Id);
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.UtcNow,
            };
            foreach (var item in requestedItems)
            {
                var product = productsById[item.productId];

                var actualQuantity = Math.Min(
                    item.Quantity,
                    product.StockQuantity);
                product.StockQuantity -= actualQuantity;
                if (actualQuantity <= 0)
                {
                    continue;
                }
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    UnitPriceAtOrder = product.UnitPrice, //beállítja,a rendeléskor aktuális árat
                    Quantity = actualQuantity, //Ha a rendelt darab nagyobb mint a készleten lévő áru akkor a készleten lévő darabot adja hozzá a rendeléshez

                };
                order.Items.Add(orderItem);
            }
            try
            {
                _context.Orders.Add(order);
                if (!order.Items.Any())
                {
                    throw new Exception("No products are available.");
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return order;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<OrderResponseDto> getOrderAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return null;
            }
            return new OrderResponseDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Items = order.Items.Select(i => new OrderItemResponseDto
                {
                    ProductId = i.ProductId,
                    UnitPriceAtOrder = i.UnitPriceAtOrder,
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}
