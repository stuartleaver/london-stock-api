using LSE.StockApi.Models;

namespace LSE.StockApi.Repositories
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
    }
}
