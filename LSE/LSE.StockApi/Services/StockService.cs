using LSE.StockApi.Models;
using LSE.StockApi.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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

        public List<Stock> GetAllStockPrices()
        {
            List<string> stockSymbols;

            try
            {
                stockSymbols = _stockRepository.GetAllStockSymbols();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured retrieving all stock symbols");

                throw;
            }

            List<Stock> stocks = new();

            foreach (var stockSymbol in stockSymbols)
            {

                var stock = GetAverageStockPriceByStockSymbol(stockSymbol);

                stocks.Add(stock);
            }

            return stocks;
        }

        public Stock GetAverageStockPriceByStockSymbol(string stockSymbol)
        {
            decimal averageStockPrice;

            try
            {
                averageStockPrice = _stockRepository.GetStockPriceByStockSymbol(stockSymbol);
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
