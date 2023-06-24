using LSE.StockApi.Models;
using System.Collections.Generic;

namespace LSE.StockApi.Services
{
    public interface IStockService
    {
        Stock GetAverageStockPriceByStockSymbol(string stockSymbol);

        List<Stock> GetAllStockPrices();
    }
}
