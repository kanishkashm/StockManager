using System.ComponentModel.DataAnnotations;

namespace SM.Core.Domain
{
    public class OrderItem
    {
        [Key]
        public int ItemId { get; set; }
        public int OrderHeaderId { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
        public int StockItemLinkId { get; set; }
        public virtual StkItem StockItemLink { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal ExclAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal InclAmount { get; set; }
        public string Note { get; set; }
    }
}
