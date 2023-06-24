using LSE.StockApi.MockDatabase;
using LSE.StockApi.Models;

namespace LSE.StockApi.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public void Add(Transaction transaction)
        {
            TransactionTable.Add(transaction);
        }
    }
}