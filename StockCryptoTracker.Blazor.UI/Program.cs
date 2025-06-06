using StockCryptoTracker.Blazor.UI.Components;
using Microsoft.AspNetCore.Components;
using StockCryptoTracker.Blazor.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();


builder.Services.AddScoped<TickerService>();
builder.Services.AddScoped<ForexService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<CommoditiesService>();
builder.Services.AddScoped<CryptocurrencyService>();
builder.Services.AddScoped<StockService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

/* Welcome to Alpha Vantage! Your API key is: 707C7G6AOH6NBYZP */