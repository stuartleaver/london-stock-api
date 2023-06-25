using FluentValidation;
using FluentValidation.AspNetCore;
using LSE.StockApi;
using LSE.StockApi.Repositories;
using LSE.StockApi.Services;
using LSE.StockApi.Validators;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

[assembly: FunctionsStartup(typeof(Startup))]
namespace LSE.StockApi
{
    [ExcludeFromCodeCoverage]
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<TransactionValidator>();

            builder.Services.AddSingleton<ITransactionService, TransactionService>();
            builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();


            builder.Services.AddSingleton<IStockService, StockService>();
            builder.Services.AddSingleton<IStockRepository, StockRepository>();

            builder.Services.AddSingleton<IStockSymbolRepository, StockSymbolRepository>();
        }
    }
}