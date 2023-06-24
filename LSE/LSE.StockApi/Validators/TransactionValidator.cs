using FluentValidation;
using LSE.StockApi.Models;

namespace LSE.StockApi.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.StockSymbol).NotEmpty().MaximumLength(5).WithMessage("Please specify a stock ticker symbol");
            RuleFor(x => x.StockPrice).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Please specify the stock price");
            RuleFor(x => x.NumberOfShares).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Please specify the number of shares transacted");
            RuleFor(x => x.BrokerId).NotEmpty().WithMessage("Please specify the Broker Id");
        }
    }
}
