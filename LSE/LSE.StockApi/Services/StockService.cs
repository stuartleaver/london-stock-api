using LSE.StockApi.Models;
using LSE.StockApi.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace LSE.StockApi.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        private readonly ILogger<StockService> _logger;

        public StockService(IStockRepository stockRepository, ILogger<StockService> logger)
        {
            _stockRepository = stockRepository;

            _logger = logger;
        }

        public Stock GetAverageStockPriceByStockSymbol(string stockSymbol)
        {
            decimal averageStockPrice;

            try
            {
                averageStockPrice = _stockRepository.GetAverageStockPriceByStockSymbol(stockSymbol);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured retrieving the average stock price", stockSymbol);

                throw;
            }

            return new Stock { StockSymbol = stockSymbol, StockPrice = averageStockPrice };
        }
    }
}
