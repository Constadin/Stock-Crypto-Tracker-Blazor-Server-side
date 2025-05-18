using StockCryptoTracker.Blazor.UI.Models;
using System.Text.Json;

namespace StockCryptoTracker.Blazor.UI.Services
{
    public class CommoditiesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "";
        public CommoditiesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommodityPriceResponse?> GetCommodityPriceAsync(string symbol)
        {
            var url = $"https://financialmodelingprep.com/api/v3/historical-price-full/{symbol}?apikey={_apiKey}";

            var response = await _httpClient.GetStringAsync(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // ΠΟΛΥ ΣΗΜΑΝΤΙΚΟ ΓΙΑ ΝΑ ΜΗΝ ΚΟΙΤΑΕΙ πεζά/κεφαλαία
            };

            var commodityData = JsonSerializer.Deserialize<CommodityPriceResponse>(response, options);

            return commodityData;
        }
    }
}
