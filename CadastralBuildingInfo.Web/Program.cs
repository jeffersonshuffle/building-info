using CadastralBuildingInfo.Presentation;
using CadastralBuildingInfo.WebApi.Middleware;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    rateLimiterOptions.AddFixedWindowLimiter("fixed", options => 
    {
        options.Window = TimeSpan.FromSeconds(20);
        options.PermitLimit = 42;
        options.QueueLimit = 50;
        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });
});
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder => builder.Cache());
});
builder.Services
    .AddApplication()
    .AddPresentation();
builder.Services.AddMemoryCache();

builder.Services.AddFiasClients();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapEndpoints();
app.UseRateLimiter();
app.UseOutputCache();

app.Run();
