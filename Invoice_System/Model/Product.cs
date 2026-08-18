using System.Diagnostics.Eventing.Reader;

namespace Invoice_System.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsHazardous { get; set; }
        public decimal Discount { get; set; }
        public int StockQuantity { get; set; }
        public bool IsFragile { get; set; }
        public bool IsDiscountEligible { get; set; }

    }
}
