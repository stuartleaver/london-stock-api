namespace LSE.StockApi.Repositories
{
    public interface IBrokerRepository
    {
        bool IsBrokerValid(int brokerId);
    }
}