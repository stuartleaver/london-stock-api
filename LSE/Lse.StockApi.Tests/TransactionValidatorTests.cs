namespace LSE.StockApi.Tests
{
    public class TransactionValidatorTests
    {
        private readonly TransactionValidator _validator;

        public TransactionValidatorTests()
        {
            _validator = new TransactionValidator();
        }

        [Fact]
        public void TransactionValidator_ShouldReturnTrue_WhenValidatingATransactionThatIsValid()
        {
            // Arrange
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
