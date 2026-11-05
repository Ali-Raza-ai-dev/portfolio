using FrontEnd.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var backendUrl = builder.Configuration["WEATHER_URL"] ?? "http://localhost:8080";

builder.Services.AddHttpClient<WeatherForecastClient>(c =>
{
    c.BaseAddress = new(backendUrl);
});

builder.Services.AddHttpClient<PortfolioApiClient>(c =>
{
    c.BaseAddress = new(backendUrl);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
