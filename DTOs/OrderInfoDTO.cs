namespace hhpw_be.DTOs
{
    public class OrderInfoDTO
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? OrderType { get; set; }
    }
}
