namespace LSE.StockApi.Tests
{
    public class StockServiceTests
    {
        private readonly Mock<IStockRepository> _stockRepository;

        private readonly Mock<ILogger<StockService>> _logger;

        private readonly IStockService _stockService;

        public StockServiceTests()
        {
            _stockRepository = new Mock<IStockRepository>();

            _logger = new Mock<ILogger<StockService>>();

            _stockService = new StockService(_stockRepository.Object, _logger.Object);
        }

        [Fact]
        public void GetAverageStockPriceByStockSymbol_ShouldReturnAnAveragePrice_WhenPassedAValidStockSymbol()
        {
            // Arrange
            var stockSymbol = "VOD";

            _stockRepository.Setup(x => x.GetStockPriceByStockSymbol(stockSymbol)).Returns(1.75m);

            var expected = new Stock { StockSymbol = stockSymbol, StockPrice = 1.75m };

            // Act
            var actual = _stockService.GetAverageStockPriceByStockSymbol(stockSymbol);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void GetAverageStockPriceByStockSymbol_ShouldReturnThrowAnError_WhenPassedAnInValidStockSymbol()
        {
            // Arrange
            var stockSymbol = "VOD3";

            _stockRepository.Setup(x => x.GetStockPriceByStockSymbol(stockSymbol)).Throws(new InvalidOperationException());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _stockService.GetAverageStockPriceByStockSymbol(stockSymbol));
        }

        [Fact]
        public void GetAverageStockPriceByStockSymbol_ShouldReturnAnAveragePriceForAllStockSymbols_WhenCalled()
        {
            // Arrange
            var stockSymbols = new List<string> { "VOD", "RMV", "EXPN" };

            _stockRepository.Setup(x => x.GetAllStockSymbols()).Returns(stockSymbols);

            _stockRepository.Setup(x => x.GetStockPriceByStockSymbol(It.IsAny<string>())).Returns(324.67m);

            var expected = new List<Stock>
            {
                new Stock { StockSymbol = "VOD", StockPrice = 324.67m},
                new Stock { StockSymbol = "RMV", StockPrice = 324.67m},
                new Stock { StockSymbol = "EXPN", StockPrice = 324.67m},
            };

            // Act
            var actual = _stockService.GetAllStockPrices();

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}