using StockCryptoTracker.Blazor.UI.Interfaces;

namespace StockCryptoTracker.Blazor.UI.Models
{
    public class ForexItem 
    {
        public string Symbol { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
    }
}
