namespace RestApiNetV1.DTOs
{
    public class ProductAmountDTO
    {
        public int Id { get; set; }
        public required string  Name { get; set; }
        public required decimal Price { get; set; }
        public required decimal Subtotal { get; set; }
        public required decimal IVA { get; set; }
        public required decimal Total { get; set; }
    }
}
