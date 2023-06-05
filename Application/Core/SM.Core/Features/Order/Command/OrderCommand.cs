using MediatR;

namespace SM.Core.Features.Order.Command
{
    public class OrderCommand : IRequest
    {
        public int CustomerId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string ReferenceNo { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal TotalExcl { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalIncl { get; set; }

        public List<OrderItemCommand> OrderItems { get; set; }
    }
}
