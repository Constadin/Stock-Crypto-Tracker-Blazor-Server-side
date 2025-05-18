using StockCryptoTracker.Blazor.UI.Models;

namespace StockCryptoTracker.Blazor.UI.Services
{
    public class StockService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "";

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StockItem>> GetStockListAsync(int limit = 500)
        {
            var url = $"https://financialmodelingprep.com/api/v3/stock/list?apikey={_apiKey}";
            var fullList = await _httpClient.GetFromJsonAsync<List<StockItem>>(url);

            return fullList?.Take(limit).ToList() ?? new List<StockItem>();
        }
    }
}
