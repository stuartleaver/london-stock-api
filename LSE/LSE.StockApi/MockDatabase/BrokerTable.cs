using LSE.StockApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace LSE.StockApi.MockDatabase
{
    public class BrokerTable
    {
        private static List<Broker> _brokers = new List<Broker>
        {
            new Broker { Id = 1, Name = "Broker 1" },
            new Broker { Id = 2, Name = "Broker 2" },
            new Broker { Id = 3, Name = "Broker 3" },
            new Broker { Id = 4, Name = "Broker 4" },
            new Broker { Id = 5, Name = "Broker 5" },
            new Broker { Id = 6, Name = "Broker 6" },
            new Broker { Id = 7, Name = "Broker 7" },
            new Broker { Id = 8, Name = "Broker 8" },
            new Broker { Id = 9, Name = "Broker 9" },
            new Broker { Id = 10, Name = "Broker 10" }
        };

        public static bool IsBrokerValid(int brokerId)
        {
            return _brokers.Any(x => x.Id == brokerId);
        }
    }
}