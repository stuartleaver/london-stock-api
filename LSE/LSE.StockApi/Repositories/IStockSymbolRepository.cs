namespace LSE.StockApi.Repositories
{
    public interface IStockSymbolRepository
    {
        bool IsStockSymbolValid(string stockSymbol);
    }
}
