using StockCryptoTracker.Blazor.UI.Models;

namespace StockCryptoTracker.Blazor.UI.Services;
public class ForexService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "";

    public ForexService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Λήψη της λίστας με τα Forex ζεύγη
    public async Task<List<ForexItem>> GetAvailableForexPairsAsync()
    {       
        try
        {
            var url = $"https://financialmodelingprep.com/stable/forex-list?apikey={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<List<ForexItem>>(url);

            return response ?? new List<ForexItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching Forex pairs: {ex.Message}");
            return new List<ForexItem>();
        }
    }
}

