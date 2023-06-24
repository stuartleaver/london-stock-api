namespace LSE.StockApi.Repositories
{
    public interface IStockRepository
    {
        decimal GetAverageStockPriceByStockSymbol(string stockSymbol);
    }
}
