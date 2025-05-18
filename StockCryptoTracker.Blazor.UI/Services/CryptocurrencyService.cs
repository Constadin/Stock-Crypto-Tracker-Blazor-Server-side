using StockCryptoTracker.Blazor.UI.Models;
using System.Text.Json;

namespace StockCryptoTracker.Blazor.UI.Services
{
    public class CryptocurrencyService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://financialmodelingprep.com/stable/historical-price-eod/full";

        
        private const string ApiKey = "";

        public CryptocurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CryptocurrencyHistoricalPriceResponse>?> GetHistoricalCryptoDataAsync(string symbol, string fromDate, string toDate)
        {
            // Ετοιμάζουμε το URL με το API key
            var url = $"{ApiBaseUrl}?symbol={symbol}&from={fromDate}&to={toDate}&apikey={ApiKey}";

            var response = await _httpClient.GetStringAsync(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Πολύ σημαντικό για να μην κοιτάει πεζά/κεφαλαία
            };

            // Επιστρέφει τη λίστα με τα ιστορικά δεδομένα
            var historicalData = JsonSerializer.Deserialize<List<CryptocurrencyHistoricalPriceResponse>>(response, options);

            return historicalData;
        }
    }
}

