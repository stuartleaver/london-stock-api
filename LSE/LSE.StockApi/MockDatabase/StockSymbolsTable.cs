using LSE.StockApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace LSE.StockApi.MockDatabase
{
    public static class StockSymbolsTable
    {
        private static List<StockSymbol> _stockSymbols = new List<StockSymbol>
        {
            new StockSymbol { Symbol = "GSK", Name = "GSK PLC ORD 31" },
            new StockSymbol { Symbol = "CRDA", Name = "CRODA INTERNATIONAL PLC ORD 10.609756P"},
            new StockSymbol { Symbol = "CTEC", Name = "CONVATEC GROUP PLC ORD 10P"},
            new StockSymbol { Symbol = "BATS", Name = "BRITISH AMERICAN TOBACCO PLC ORD 25P"},
            new StockSymbol { Symbol = "PSON", Name = "PEARSON PLC ORD 25P"},
            new StockSymbol { Symbol = "VOD", Name = "VODAFONE GROUP PLC ORD USD0.20 20/21"},
            new StockSymbol { Symbol = "IMB", Name = "IMPERIAL BRANDS PLC ORD 10P"},
            new StockSymbol { Symbol = "HLMA", Name = "HALMA PLC ORD 10P"},
            new StockSymbol { Symbol = "SN.", Name = "SMITH & NEPHEW PLC ORD USD0.20"},
            new StockSymbol { Symbol = "ADM", Name = "ADMIRAL GROUP PLC ORD 0.1P"},
            new StockSymbol { Symbol = "RMV", Name = "RIGHTMOVE PLC ORD 0.1P"},
            new StockSymbol { Symbol = "ABF", Name = "ASSOCIATED BRITISH FOODS PLC ORD 5 15/22P"},
            new StockSymbol { Symbol = "ULVR", Name = "UNILEVER PLC ORD 3 1/9P"},
            new StockSymbol { Symbol = "EXPN", Name = "EXPERIAN PLC ORD USD0.10"},
            new StockSymbol { Symbol = "EDV", Name = "ENDEAVOUR MINING PLC ORD USD0.01"},
            new StockSymbol { Symbol = "RKT", Name = "RECKITT BENCKISER GROUP PLC ORD 10P"},
            new StockSymbol { Symbol = "HLN", Name = "HALEON PLC ORD GBP0.01"},
            new StockSymbol { Symbol = "WEIR", Name = "WEIR GROUP PLC ORD 12.5P"},
            new StockSymbol { Symbol = "MNDI", Name = "MONDI PLC ORD EUR 0.20"},
            new StockSymbol { Symbol = "AUTO", Name = "AUTO TRADER GROUP PLC ORD 1P" }
        };

        public static bool IsStockSymbolValid(string stockSymbol)
        {
            return _stockSymbols.Any(x => x.Symbol == stockSymbol);
        }
    }
}



