using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LSE.StockApi.Models;

namespace LSE.StockApi
{
    public static class TransactionFunction
    {
        [FunctionName("TransactionFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "transaction")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Transaction function processed a request at {DateTime.Now}.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                var data = JsonConvert.DeserializeObject<Transaction>(requestBody);
            }
            catch(Exception ex)
            {
                log.LogError(ex, "An error occured deserialising the request body", requestBody);

                return new BadRequestObjectResult(ex.Message);
            }

            return new OkObjectResult("Transaction received");
        }
    }
}
