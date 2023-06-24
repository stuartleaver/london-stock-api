using LSE.StockApi.Models;

namespace LSE.StockApi.Services
{
    public interface IStockService
    {
        Stock GetAverageStockPriceByStockSymbol(string stockSymbol);
    }
}
