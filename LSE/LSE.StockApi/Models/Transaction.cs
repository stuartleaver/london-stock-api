using Newtonsoft.Json;

namespace LSE.StockApi.Models
{
    public class Transaction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stockPrice")]
        public decimal StockPrice { get; set; }

        [JsonProperty("numberOfShares")]
        public decimal NumberOfShares { get; set; }

        [JsonProperty("brokerId")]
        public int BrokerId { get; set; }
    }
}
