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
using FluentValidation;
using System.Linq;

namespace LSE.StockApi
{
    public class TransactionFunction
    {
        private readonly IValidator<Transaction> _validator;

        public TransactionFunction(IValidator<Transaction> validator)
        {
            _validator = validator;
        }

        [FunctionName("TransactionFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "transaction")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Transaction function processed a request at {DateTime.Now}.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Transaction data;

            try
            {
                data = JsonConvert.DeserializeObject<Transaction>(requestBody);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occured deserialising the request body", requestBody);

                return new BadRequestObjectResult(ex.Message);
            }

            var validationResult = await _validator.ValidateAsync(data);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors.Select(e => new
                {
                    e.PropertyName,
                    e.ErrorMessage
                }));
            }

            return new OkObjectResult("Transaction received");
        }
    }
}
