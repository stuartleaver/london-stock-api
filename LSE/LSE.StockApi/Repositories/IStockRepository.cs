using System.Collections.Generic;

namespace LSE.StockApi.Repositories
{
    public interface IStockRepository
    {
        decimal GetStockPriceByStockSymbol(string stockSymbol);

        List<string> GetAllStockSymbols();
    }
}
