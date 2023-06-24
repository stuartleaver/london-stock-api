using LSE.StockApi.Models;

namespace LSE.StockApi.Services
{
    public interface ITransactionService
    {
        void ProcessTransaction(Transaction transaction);
    }
}
