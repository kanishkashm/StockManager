namespace SM.Core.Features.Order.Command
{
    public class OrderItemCommand
    {
        public int index { get; set; }
        public int StockItemLinkId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal ExclAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal InclAmount { get; set; }
        public string Note { get; set; }
    }
}
