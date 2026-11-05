using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PortfolioDataService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure OpenAPI
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, ct) =>
    {
        document.Servers = [];
        return Task.CompletedTask;
    });
});

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// API Endpoints
var api = app.MapGroup("/api");

api.MapGet("/profile", (PortfolioDataService service) => Results.Ok(service.GetProfile()))
   .WithName("GetProfile")
   .WithSummary("Get Ali Raza's profile, bio, social links, and summary metrics");

api.MapGet("/projects", (PortfolioDataService service, string? category) =>
{
    var projects = service.GetProjects();
    if (!string.IsNullOrWhiteSpace(category) && !category.Equals("all", StringComparison.OrdinalIgnoreCase))
    {
        projects = projects.Where(p => p.Category.Contains(category, StringComparison.OrdinalIgnoreCase)
                                     || p.TechStack.Any(t => t.Equals(category, StringComparison.OrdinalIgnoreCase))).ToList();
    }
    return Results.Ok(projects);
})
.WithName("GetProjects")
.WithSummary("Get all portfolio projects with optional filtering");

api.MapGet("/projects/{slug}", (PortfolioDataService service, string slug) =>
{
    var project = service.GetProjects().FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
    return project is not null ? Results.Ok(project) : Results.NotFound(new { Message = $"Project '{slug}' not found." });
})
.WithName("GetProjectBySlug")
.WithSummary("Get detailed case study information for a project by slug");

api.MapGet("/services", (PortfolioDataService service) => Results.Ok(service.GetServices()))
   .WithName("GetServices")
   .WithSummary("Get list of AI and automation services offered");

api.MapGet("/services/{slug}", (PortfolioDataService service, string slug) =>
{
    var s = service.GetServices().FirstOrDefault(x => x.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
    return s is not null ? Results.Ok(s) : Results.NotFound(new { Message = $"Service '{slug}' not found." });
})
.WithName("GetServiceBySlug")
.WithSummary("Get service details by slug");

api.MapGet("/certificates", (PortfolioDataService service) => Results.Ok(service.GetCertificates()))
   .WithName("GetCertificates")
   .WithSummary("Get verified certificates, credentials, and achievements");

api.MapGet("/experience", (PortfolioDataService service) => Results.Ok(new
{
    Experience = service.GetExperience(),
    Education = service.GetEducation()
}))
.WithName("GetExperience")
.WithSummary("Get career experience timeline and educational history");

api.MapGet("/skills", (PortfolioDataService service) => Results.Ok(service.GetSkills()))
   .WithName("GetSkills")
   .WithSummary("Get categorized technical skills matrix");

api.MapPost("/contact", (PortfolioDataService service, ContactMessageRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Message))
    {
        return Results.BadRequest(new { Success = false, Message = "Name, email, and message are required." });
    }

    var result = service.RecordContactMessage(request);
    return Results.Ok(result);
})
.WithName("SubmitContactMessage")
.WithSummary("Submit an inquiry or contact message to Ali Raza");

api.MapGet("/contact/submissions", (PortfolioDataService service) => Results.Ok(service.GetSubmissions()))
   .WithName("GetContactSubmissions")
   .WithSummary("View submitted contact inquiries (debug / admin)");

api.MapGet("/health", () => Results.Ok(new
{
    Status = "Healthy",
    Platform = ".NET 10 & Blazor",
    Timestamp = DateTime.UtcNow
}))
.WithName("HealthCheck")
.WithSummary("Service health status check");

// Preserve Weather Forecast sample endpoint for backward compatibility
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
