namespace LSE.StockApi.Tests
{
    public class StockPriceFunctionTests
    {
        private readonly Mock<IStockService> _stockService;

        private readonly Mock<ILogger> _logger;

        private readonly StockPriceFunction _stockPriceFunction;

        public StockPriceFunctionTests()
        {
            _stockService = new Mock<IStockService>();

            _logger = new Mock<ILogger>();

            _stockPriceFunction = new StockPriceFunction(_stockService.Object);
        }

        [Fact]
        public void GetStockPriceAll_ShouldReturnOkObjestResultAndCorrectBody_WhenPassedAValidTransaction()
        {
            // Arrange
            var stocks = new List<Stock>
            {
                new Stock { StockSymbol = "VOD", StockPrice = 1.25m},
                new Stock { StockSymbol = "RMV", StockPrice = 34.50m}
            };

            _stockService.Setup(x => x.GetAllStockPrices()).Returns(stocks);

            var request = new Mock<HttpRequest>();

            // Act
            var response = _stockPriceFunction.GetStockPriceAll(request.Object, _logger.Object);

            // Assert
            var actual = response as OkObjectResult;

            Assert.Equal(typeof(OkObjectResult), response.GetType());

            Assert.Equivalent(stocks, actual?.Value);
        }

        [Fact]
        public void GetStockPriceByStockSymbol_ShouldReturnOkObjestResultAndCorrectBody_WhenPassedAValidStockSymbol()
        {
            // Arrange
            var request = new Mock<HttpRequest>();

            var stock = new Stock
            {
                StockSymbol = "RMV",
                StockPrice = 23.87m
            };

            _stockService.Setup(x => x.GetStockPriceByStockSymbol("RMV")).Returns(stock);

            // Act
            var response = _stockPriceFunction.GetStockPriceByStockSymbol(request.Object, "RMV", _logger.Object);

            // Assert
            var actual = response as OkObjectResult;

            Assert.Equal(typeof(OkObjectResult), response.GetType());

            Assert.Equivalent(stock, actual?.Value);
        }

        [Fact]
        public void GetStockPriceByStockSymbol_ShouldReturnNotFoundObjectResult_WhenPassedAnInvalidStockSymbol()
        {
            // Arrange
            var request = new Mock<HttpRequest>();

            _stockService.Setup(x => x.GetStockPriceByStockSymbol("987")).Throws(new Exception());

            // Act
            var response = _stockPriceFunction.GetStockPriceByStockSymbol(request.Object, "987", _logger.Object);

            // Assert
            Assert.Equal(typeof(NotFoundObjectResult), response.GetType());
        }

        [Fact]
        public async Task GetStockPriceByStockSymbolListAsync_ShouldReturnOkObjestResult_WhenPassedAValidListOfStockSymbols()
        {
            // Arrange
            var stockSymbolList = new string[] { "VOD", "RMV" };

            var request = MockRequestHelper.CreateMockRequest(stockSymbolList);

            _stockService.Setup(x => x.GetStockPricesByList(It.IsAny<List<string>>())).Returns(It.IsAny<List<Stock>>);

            // Act
            var response = await _stockPriceFunction.GetStockPriceByStockSymbolListAsync(request.Object, _logger.Object);

            // Assert
            Assert.Equal(typeof(OkObjectResult), response.GetType());
        }
    }
}