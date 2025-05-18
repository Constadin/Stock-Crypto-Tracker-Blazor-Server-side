namespace StockCryptoTracker.Blazor.UI.Models
{
    public class CommodityPriceResponse
    {
        public string Symbol { get; set; } = string.Empty;
        public List<CommodityHistoricalItem> Historical { get; set; } = new();
    }

    public class CommodityHistoricalItem
    {
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double AdjClose { get; set; }
        public int Volume { get; set; }
        public int UnadjustedVolume { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public double Vwap { get; set; }
        public string Label { get; set; } = string.Empty;
        public double ChangeOverTime { get; set; }
    }
}
