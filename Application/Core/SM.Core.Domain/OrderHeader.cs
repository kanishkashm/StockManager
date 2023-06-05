using System.ComponentModel.DataAnnotations;

namespace SM.Core.Domain
{
    public class OrderHeader
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual Client Customer { get; set; }
        public  string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string ReferenceNo { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal TotalExcl { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalIncl { get; set; }
    }
}
