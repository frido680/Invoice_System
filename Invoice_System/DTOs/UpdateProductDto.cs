namespace Invoice_System.DTOs
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool IsHazardous { get; set; }
        public bool IsFragile { get; set; }
        public int StockQuantity { get; set; }
    }
}
