namespace hhpw_be.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string OrderType { get; set; }
        public bool IsClosed { get; set; }
        public decimal Total { get; set; }
        public DateTime DateClosed { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
