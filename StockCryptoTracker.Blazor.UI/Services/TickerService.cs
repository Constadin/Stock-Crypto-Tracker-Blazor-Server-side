using StockCryptoTracker.Blazor.UI.Models;

namespace StockCryptoTracker.Blazor.UI.Services
{
    public class TickerService
    {
        private readonly HttpClient _httpClient;
        public TickerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Dictionary<string, decimal>> GetCryptoPricesAsync()
        {
            var prices = new Dictionary<string, decimal>();

            try
            {
                var response = await _httpClient.GetFromJsonAsync<Dictionary<string, Dictionary<string, decimal>>>(
                    "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,cardano,dogecoin,solana,tether,tron&vs_currencies=usd");

                if (response != null)
                {
                    prices["BTC"] = response["bitcoin"]["usd"];
                    prices["ETH"] = response["ethereum"]["usd"];
                    prices["ADA"] = response["cardano"]["usd"];
                    prices["DOGE"] = response["dogecoin"]["usd"];
                    prices["SOL"] = response["solana"]["usd"];
                    prices["USDT"] = response["tether"]["usd"];
                    prices["TRX"] = response["tron"]["usd"];
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"TickerService Error: {ex.Message}");
            }

            return prices;
        }

        public async Task<Dictionary<string, decimal>> GetStockPricesAsync()
        {
            // Fake δεδομένα stocks
            var fakePrices = new Dictionary<string, decimal>
            {
                { "AAPL", 172.45m },
                { "MSFT", 321.12m },
                { "GOOGL", 2854.67m },
                { "AMZN", 3478.05m },
                { "TSLA", 754.23m },
                { "META", 326.22m },
                { "NFLX", 443.19m },
                { "NVDA", 720.55m },
                { "BABA", 89.32m },
                { "DIS", 95.74m },
                { "INTC", 34.76m },
                { "AMD", 112.38m },
                { "PYPL", 72.48m },
                { "UBER", 61.77m },
                { "LYFT", 14.32m },
                { "SHOP", 64.53m },
                { "SQ", 72.16m },
                { "CRM", 223.55m },
                { "ORCL", 108.43m }
            };

            await Task.Delay(500); // Μικρή καθυστέρηση για ρεαλιστικό async feeling

            return fakePrices;
        }



    }
}
