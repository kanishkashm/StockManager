using FluentValidation;

namespace SM.Core.Features.Order.Command
{
    public class OrderItemCommandValidator : AbstractValidator<OrderItemCommand>
    {
        public OrderItemCommandValidator()
        {
            RuleFor(oi => oi.StockItemLinkId)
                .NotEmpty().WithMessage("{StockItemLinkId} is required.")
                .NotNull();
            RuleFor(oi => oi.Quantity)
                .NotEmpty().WithMessage("{Quantity} is required.")
                .NotNull();
            RuleFor(oi => oi.Tax)
                .NotEmpty().WithMessage("{Tax} is required.")
                .NotNull();
        }
    }
}
