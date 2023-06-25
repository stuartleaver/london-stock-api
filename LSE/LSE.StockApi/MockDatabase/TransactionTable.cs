using LSE.StockApi.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LSE.StockApi.MockDatabase
{
    [ExcludeFromCodeCoverage]
    public static class TransactionTable
    {
        private static List<Transaction> _transactions = new();

        public static void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public static decimal GetStockPriceByStockSymbol(string stockSymbol)
        {
            return _transactions.Where(x => x.StockSymbol == stockSymbol).Average(x => x.StockPrice);
        }

        public static List<string> GetAllStockSymbols()
        {
            return _transactions.Select(x => x.StockSymbol).Distinct().ToList();
        }
    }
}