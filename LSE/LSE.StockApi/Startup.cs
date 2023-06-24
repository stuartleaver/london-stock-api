using FluentValidation;
using FluentValidation.AspNetCore;
using LSE.StockApi;
using LSE.StockApi.Validators;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace LSE.StockApi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<TransactionValidator>();
        }
    }
}