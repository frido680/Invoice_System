using Microsoft.AspNetCore.Mvc;
using Invoice_System.DTOs;
using Invoice_System.Services;

namespace Invoice_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderServices _orderServices;
        public OrderController(OrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            var order = await _orderServices.CreateOrderAsync(dto);
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderServices.getOrderAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
