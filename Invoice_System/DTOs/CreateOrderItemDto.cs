using System.ComponentModel.DataAnnotations;

namespace Invoice_System.DTOs
{
    public class CreateOrderItemDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
