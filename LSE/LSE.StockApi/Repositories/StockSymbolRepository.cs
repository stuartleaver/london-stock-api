using LSE.StockApi.MockDatabase;

namespace LSE.StockApi.Repositories
{
    public class StockSymbolRepository : IStockSymbolRepository
    {
        public bool IsStockSymbolValid(string stockSymbol)
        {
            return StockSymbolsTable.IsStockSymbolValid(stockSymbol);
        }
    }
}