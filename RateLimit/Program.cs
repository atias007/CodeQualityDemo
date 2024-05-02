// https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit?view=aspnetcore-8.0

// host.docker.internal:7281/WeatherForecast

using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Depedency Injection

builder.Services.AddRateLimiter(rateOpt =>
    {
        rateOpt.AddFixedWindowLimiter(policyName: "fixed", options =>
        {
            options.PermitLimit = 50;
            options.Window = TimeSpan.FromSeconds(1);
            ////            options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            ////            options.QueueLimit = 1;
        });

        rateOpt.AddConcurrencyLimiter(policyName: "conc", opt =>
        {
            opt.PermitLimit = 10;
        });

        rateOpt.RejectionStatusCode = 429; // TooManyRequests
    });

#endregion Depedency Injection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#region Middleware

app.UseRateLimiter();

#endregion Middleware

app.Run();