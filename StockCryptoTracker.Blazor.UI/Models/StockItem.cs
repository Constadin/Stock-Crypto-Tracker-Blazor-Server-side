namespace StockCryptoTracker.Blazor.UI.Models
{
    public class StockItem
    {
        public string Symbol { get; set; }
        public string Exchange { get; set; }
        public string ExchangeShortName { get; set; }
        public decimal? Price { get; set; }
        public string Name { get; set; }
    }
}
