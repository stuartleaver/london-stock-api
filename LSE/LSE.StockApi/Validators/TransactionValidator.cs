using FluentValidation;
using LSE.StockApi.Models;
using LSE.StockApi.Repositories;

namespace LSE.StockApi.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        private readonly IStockSymbolRepository _stockSymbolRepository;

        public TransactionValidator(IStockSymbolRepository stockSymbolRepository)
        {
            _stockSymbolRepository = stockSymbolRepository;

            RuleFor(x => x.StockSymbol).NotEmpty().MaximumLength(5).Must(x => BeAValidStockSymbol(x)).WithMessage("Please specify a valid stock ticker symbol");
            RuleFor(x => x.StockPrice).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Please specify the stock price");
            RuleFor(x => x.NumberOfShares).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Please specify the number of shares transacted");
            RuleFor(x => x.BrokerId).NotEmpty().WithMessage("Please specify the Broker Id");
        }

        private bool BeAValidStockSymbol(string stockSymbol)
        {
            return _stockSymbolRepository.IsStockSymbolValid(stockSymbol);
        }
    }
}