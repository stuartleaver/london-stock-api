using Newtonsoft.Json;

namespace LSE.StockApi.Models
{
    public class Stock
    {
        [JsonProperty("stockSymbol")]
        public string StockSymbol { get; set; }

        [JsonProperty("stockPrice")]
        public decimal StockPrice { get; set; }
    }
}