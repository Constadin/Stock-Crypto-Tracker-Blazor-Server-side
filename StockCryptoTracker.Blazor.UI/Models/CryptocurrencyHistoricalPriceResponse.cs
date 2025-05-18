using System.Text.Json.Serialization;

namespace StockCryptoTracker.Blazor.UI.Models
{
    public class CryptocurrencyHistoricalPriceResponse
    {
        public string Symbol { get; set; }
        public string Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal Vwap { get; set; }
    }
}
