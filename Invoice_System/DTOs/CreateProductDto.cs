using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace Invoice_System.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }
        [Range(0, 100)]
        public decimal Discount { get; set; }
        public bool IsHazardous { get; set; }
        public bool IsFragile { get; set; }
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}
