using LSE.StockApi.MockDatabase;
using System.Collections.Generic;

namespace LSE.StockApi.Repositories
{
    public class StockRepository : IStockRepository
    {
        public decimal GetStockPriceByStockSymbol(string stockSymbol)
        {
            return TransactionTable.GetStockPriceByStockSymbol(stockSymbol);
        }

        public List<string> GetAllStockSymbols()
        {
            return TransactionTable.GetAllStockSymbols();
        }
    }
}
