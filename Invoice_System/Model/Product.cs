namespace Invoice_System.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public bool isHazardous { get; set; }
        public decimal Discount { get; set; } //százalékban értendő
        public int StockQuantity { get; set; }
        public bool isDiscountEligible => Discount > 0;

    }
}
