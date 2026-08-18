using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Invoice_System.DTOs
{
    public class CreateCustomerDto
    {
        [Required]
        [MaxLength]
        public string Name { get; set; }
        [Required]
        [MaxLength(350)]
        public string Country { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
    }
}
