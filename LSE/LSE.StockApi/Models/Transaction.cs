using Newtonsoft.Json;

namespace LSE.StockApi.Models
{
    public class Transaction : Stock
    {
        [JsonProperty("numberOfShares")]
        public decimal NumberOfShares { get; set; }

        [JsonProperty("brokerId")]
        public int BrokerId { get; set; }
    }
}
