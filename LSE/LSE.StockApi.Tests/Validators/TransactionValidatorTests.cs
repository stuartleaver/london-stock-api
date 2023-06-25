namespace LSE.StockApi.Tests.Validators
{
    public class TransactionValidatorTests
    {
        private readonly TransactionValidator _validator;

        private readonly Mock<IStockSymbolRepository> _stockSymbolRepository;

        public TransactionValidatorTests()
        {
            _stockSymbolRepository = new Mock<IStockSymbolRepository>();

            _validator = new TransactionValidator(_stockSymbolRepository.Object);
        }

        [Fact]
        public void TransactionValidator_ShouldReturnTrue_WhenValidatingATransactionThatIsValid()
        {
            // Arrange
            _stockSymbolRepository.Setup(x => x.IsStockSymbolValid(It.IsAny<string>())).Returns(true);

            var transaction = new Transaction { StockSymbol = "VOD", StockPrice = 1.50m, NumberOfShares = 10, BrokerId = 123456 };

            // Act
            var result = _validator.Validate(transaction).IsValid;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TransactionValidator_ShouldReturnFalse_WhenValidatingATransactionWithAnEmptyStockSymbol()
        {
            // Arrange
            var transaction = new Transaction { StockSymbol = "", StockPrice = 1.50m, NumberOfShares = 10, BrokerId = 123456 };

            // Act
            var result = _validator.Validate(transaction).IsValid;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TransactionValidator_ShouldReturnFalse_WhenValidatingATransactionWithAStockSymbolThatIsToLong()
        {
            // Arrange
            var transaction = new Transaction { StockSymbol = "VODVOD", StockPrice = 1.50m, NumberOfShares = 10, BrokerId = 123456 };

            // Act
            var result = _validator.Validate(transaction).IsValid;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TransactionValidator_ShouldReturnFalse_WhenValidatingATransactionWithAnInvalidStockSymbol()
        {
            // Arrange
            _stockSymbolRepository.Setup(x => x.IsStockSymbolValid(It.IsAny<string>())).Returns(false);

            var transaction = new Transaction { StockSymbol = "123", StockPrice = 1.50m, NumberOfShares = 10, BrokerId = 123456 };

            // Act
            var result = _validator.Validate(transaction).IsValid;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TransactionValidator_ShouldReturnFalse_WhenValidatingATransactionWithAnEmptyStockPrice()
        {
            // Arrange
            var transaction = new Transaction { StockSymbol = "VOD", StockPrice = 0m, NumberOfShares = 10, BrokerId = 123456 };

            // Act
            var result = _validator.Validate(transaction).IsValid;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TransactionValidator_ShouldReturnFalse_WhenValidatingATransactionWithAnEmptyNumberOfShares()
        {
            // Arrange
            var transaction = new Transaction { StockSymbol = "VOD", StockPrice = 1.5m, NumberOfShares = 0, BrokerId = 123456 };

            // Act
            var result = _validator.Validate(transaction).IsValid;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TransactionValidator_ShouldReturnFalse_WhenValidatingATransactionWithAnEmptyBrokerId()
        {
            // Arrange
            var transaction = new Transaction { StockSymbol = "VOD", StockPrice = 1.5m, NumberOfShares = 10, BrokerId = 0 };

            // Act
            var result = _validator.Validate(transaction).IsValid;

            // Assert
            Assert.False(result);
        }
    }
}