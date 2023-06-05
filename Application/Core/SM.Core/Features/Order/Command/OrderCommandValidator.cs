using FluentValidation;

namespace SM.Core.Features.Order.Command
{
    public class OrderCommandValidator : AbstractValidator<OrderCommand>
    {
        public OrderCommandValidator()
        {
            RuleFor(o => o.CustomerId)
                .NotEmpty().WithMessage("{CustomerId} is required.")
                .NotNull();
            RuleFor(o => o.InvoiceNo)
                .NotEmpty().WithMessage("{InvoiceNo} is required.")
                .NotNull();
            RuleFor(o => o.InvoiceDate)
               .NotEmpty().WithMessage("{InvoiceDate} is required.")
               .NotNull();
            RuleFor(o => o.ReferenceNo)
               .NotEmpty().WithMessage("{ReferenceNo} is required.")
               .NotNull();
            RuleForEach(x => x.OrderItems).SetValidator(new OrderItemCommandValidator());
        }
    }
}
