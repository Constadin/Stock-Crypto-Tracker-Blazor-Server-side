using StockCryptoTracker.Blazor.UI.Models;

namespace StockCryptoTracker.Blazor.UI.Services
{
    public class ArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "";

        private static DateTime _lastRequestTime = DateTime.MinValue;
        private static readonly TimeSpan RequestInterval = TimeSpan.FromSeconds(1); // 1 request/sec

        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ArticleItem>> GetArticlesAsync(int page = 0, int limit = 9)
        {
            // Έλεγχος για throttling
            var timeSinceLastRequest = DateTime.UtcNow - _lastRequestTime;
            if (timeSinceLastRequest < RequestInterval)
            {
                var delay = RequestInterval - timeSinceLastRequest;
                await Task.Delay(delay);
            }

            var url = $"https://financialmodelingprep.com/stable/fmp-articles?page={page}&limit={limit}&apikey={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<List<ArticleItem>>(url);

            _lastRequestTime = DateTime.UtcNow; // Ενημερώνουμε το πότε έγινε το τελευταίο request

            return response ?? new List<ArticleItem>();
        }
    }
}

