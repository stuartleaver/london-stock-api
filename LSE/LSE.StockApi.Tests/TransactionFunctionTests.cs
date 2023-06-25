namespace LSE.StockApi.Tests
{
    public class TransactionFunctionTests
    {
        private readonly Mock<IValidator<Transaction>> _validator;

        private readonly Mock<ITransactionService> _transactionService;

        private readonly Mock<ILogger> _logger;

        private readonly TransactionFunction _transactionFunction;

        public TransactionFunctionTests()
        {
            _validator = new Mock<IValidator<Transaction>>();

            _transactionService = new Mock<ITransactionService>();

            _logger = new Mock<ILogger>();

            _transactionFunction = new TransactionFunction(_validator.Object, _transactionService.Object);
        }

        [Fact]
        public async Task RecieveTransaction_ShouldReturnOkObjestResult_WhenPassedAValidTransaction()
        {
            // Arrange
            var transaction = new Transaction
            {
                StockSymbol = "RMV",
                StockPrice = 15m,
                NumberOfShares = 2,
                BrokerId = 123456
            };

            var request = MockRequestHelper.CreateMockRequest(transaction);

            _validator.Setup(x => x.ValidateAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());

            // Act
            var response = await _transactionFunction.RecieveTransaction(request.Object, _logger.Object);

            // Assert
            Assert.Equal(typeof(OkObjectResult), response.GetType());
        }

        [Fact]
        public async Task RecieveTransaction_ShouldReturnBadRequestObjectResult_WhenPassedAnInvalidTransaction()
        {
            // Arrange
            var transaction = new Transaction
            {
                StockSymbol = "RMV",
                StockPrice = 15m,
                NumberOfShares = 2,
                BrokerId = 123456
            };

            var request = MockRequestHelper.CreateMockRequest(transaction);

            _validator.Setup(x => x.ValidateAsync(It.IsAny<Transaction>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure
                {
                    PropertyName = nameof(Transaction.StockSymbol),
                }
            }));

            // Act
            var response = await _transactionFunction.RecieveTransaction(request.Object, _logger.Object);

            // Assert
            Assert.Equal(typeof(BadRequestObjectResult), response.GetType());
        }
    }
}