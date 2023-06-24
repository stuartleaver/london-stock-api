using LSE.StockApi.MockDatabase;

namespace LSE.StockApi.Repositories
{
    public class StockRepository : IStockRepository
    {
        public decimal GetAverageStockPriceByStockSymbol(string stockSymbol)
        {
            return TransactionTable.GetAverageStockPriceByStockSymbol(stockSymbol);
        }
    }
}
