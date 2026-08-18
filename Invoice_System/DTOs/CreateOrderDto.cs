using System.ComponentModel.DataAnnotations;
using Invoice_System.DTOs;

namespace Invoice_System.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [MinLength(1)]
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
