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
        public void GetStockPriceByStockSymbol_ShouldReturnAPrice_WhenPassedAValidStockSymbol()
        {
            // Arrange
            var stockSymbol = "VOD";

            _stockRepository.Setup(x => x.GetStockPriceByStockSymbol(stockSymbol)).Returns(1.75m);

            var expected = new Stock { StockSymbol = stockSymbol, StockPrice = 1.75m };

            // Act
            var actual = _stockService.GetStockPriceByStockSymbol(stockSymbol);

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
            Assert.Throws<InvalidOperationException>(() => _stockService.GetStockPriceByStockSymbol(stockSymbol));
        }

        [Fact]
        public void GetAllStockPrices_ShouldReturnAPriceForAllStockSymbols_WhenCalled()
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

        [Fact]
        public void GetStockPricesByList_ShouldReturnAPriceForGivenStockSymbols_WhenPassedAListOfStockSymbols()
        {
            // Arrange
            var stockSymbols = new List<string> { "ULVR", "AUTO" };

            _stockRepository.Setup(x => x.GetStockPriceByStockSymbol(It.IsAny<string>())).Returns(44.23m);

            var expected = new List<Stock>
            {
                new Stock { StockSymbol = "ULVR", StockPrice = 44.23m},
                new Stock { StockSymbol = "AUTO", StockPrice = 44.23m}
            };

            // Act
            var actual = _stockService.GetStockPricesByList(stockSymbols);

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}