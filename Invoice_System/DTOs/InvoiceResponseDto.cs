namespace Invoice_System.DTOs
{
    public class InvoiceResponseDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public List<InvoiceLineDto> Lines { get; set; } = new();

        public decimal TotalAmount { get; set; }
    }
    public class InvoiceLineDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }
        public bool IsDiscountEligible { get; set; }
        public bool IsFragile { get; set; }

        public decimal LineTotal { get; set; }
    }

}