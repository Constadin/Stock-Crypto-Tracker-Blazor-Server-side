namespace StockCryptoTracker.Blazor.UI.Interfaces
{
    // Δημιουργία ενός κοινού interface για τα αντικείμενα που θα βρίσκονται στην AllPrices
    public interface IPriceItem
    {
        string Symbol { get; set; }
        decimal Price { get; set; }
        string ImageUrl { get; set; }
        string Type { get; set; }
    }
}
