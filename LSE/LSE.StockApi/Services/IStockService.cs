using LSE.StockApi.Models;
using System.Collections.Generic;

namespace LSE.StockApi.Services
{
    public interface IStockService
    {
        Stock GetStockPriceByStockSymbol(string stockSymbol);

        List<Stock> GetAllStockPrices();

        List<Stock> GetStockPricesByList(List<string> stockSymbols);
    }
}