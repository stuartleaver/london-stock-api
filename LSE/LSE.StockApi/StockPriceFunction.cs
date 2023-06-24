using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LSE.StockApi.Services;
using System;
using LSE.StockApi.Models;
using System.Collections.Generic;

namespace LSE.StockApi
{
    public class StockPriceFunction
    {
        private readonly IStockService _stockService;

        public StockPriceFunction(IStockService stockService)
        {
            _stockService = stockService;
        }

        [FunctionName("StockPriceFunction")]
        public IActionResult GetStockPriceAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stockprice")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Stock price all function processed a request at {DateTime.Now}.");

            List<Stock> stocks;

            try
            {
                stocks = _stockService.GetAllStockPrices();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occured while retrieving all stock prices");

                return new BadRequestResult();
            }

            return new OkObjectResult(stocks);
        }

        [FunctionName("StockPriceFunctionByStockSymbol")]
        public IActionResult GetStockPriceByStockSymbol(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stockprice/{stockSymbol}")] HttpRequest req,
            string stockSymbol,
            ILogger log)
        {
            log.LogInformation($"Stock price by stock symbol function processed a request at {DateTime.Now}.");

            Stock stock;

            try
            {
                stock = _stockService.GetAverageStockPriceByStockSymbol(stockSymbol);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Stock symbol not found", stockSymbol);

                return new NotFoundObjectResult(stockSymbol);
            }

            return new OkObjectResult(stock);
        }
    }
}
