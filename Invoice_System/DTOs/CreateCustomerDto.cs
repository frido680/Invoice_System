using System.ComponentModel.DataAnnotations;

namespace Invoice_System.DTOs
{
    public class CreateCustomerDto
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [MaxLength(350)]
        public string Country { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
    }
}
