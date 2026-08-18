namespace Invoice_System.Model
{
    public class OrderItem
    {
        //Ref to Order, Ref to Product, Quantity
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
