using LSE.StockApi.MockDatabase;

namespace LSE.StockApi.Repositories
{
    public class BrokerRepository : IBrokerRepository
    {
        public bool IsBrokerValid(int brokerId)
        {
            return BrokerTable.IsBrokerValid(brokerId);
        }
    }
}