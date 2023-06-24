using LSE.StockApi.Models;
using LSE.StockApi.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace LSE.StockApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        private readonly ILogger<TransactionService> _logger;

        public TransactionService(ITransactionRepository transactionRepository, ILogger<TransactionService> logger)
        {
            _transactionRepository = transactionRepository;

            _logger = logger;
        }

        public void ProcessTransaction(Transaction transaction)
        {
            try
            {
                _transactionRepository.Add(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured comitting the transaction");
            }
        }
    }
}
