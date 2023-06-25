namespace LSE.StockApi.Tests.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<ITransactionRepository> _transactionRepository;

        private readonly Mock<ILogger<TransactionService>> _logger;

        private readonly ITransactionService _transactionService;

        public TransactionServiceTests()
        {
            _transactionRepository = new Mock<ITransactionRepository>();

            _logger = new Mock<ILogger<TransactionService>>();

            _transactionService = new TransactionService(_transactionRepository.Object, _logger.Object);
        }

        [Fact]
        public void ProcessTransaction_ShouldCallTheTransactionRepositoryAdd_WhenCalled()
        {
            // Arrange
            var transaction = new Transaction { StockSymbol = "VOD", StockPrice = 1.50m, NumberOfShares = 10, BrokerId = 123456 };

            // Act
            _transactionService.ProcessTransaction(transaction);

            // Assert
            _transactionRepository.Verify(x => x.Add(transaction), Times.Once);
        }
    }
}