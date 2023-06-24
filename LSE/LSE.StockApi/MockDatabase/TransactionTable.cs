using LSE.StockApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace LSE.StockApi.MockDatabase
{
    public static class TransactionTable
    {
        private static List<Transaction> _transactions = new();

        public static void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public static decimal GetAverageStockPriceByStockSymbol(string stockSymbol)
        {
            return _transactions.Where(x => x.StockSymbol == stockSymbol).Average(x => x.StockPrice);
        }
    }
}