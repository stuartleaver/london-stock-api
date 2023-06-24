using LSE.StockApi.Models;
using System.Collections.Generic;

namespace LSE.StockApi.MockDatabase
{
    public static class TransactionTable
    {
        private static List<Transaction> _transactions = new();

        public static void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
    }
}