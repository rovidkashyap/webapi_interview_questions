using System.Reflection.PortableExecutable;
using static caching_in_web_api.Controllers.HomeController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddStackExchangeRedisCache(options =>      // Add Redis Cache for Distribute Caching
{
    options.Configuration = "localhost:6600";
});

builder.Services.AddControllers();
builder.Services.AddMemoryCache();  // Add In-Memory Caching
builder.Services.AddSingleton<IProductRepository, ProductRepository>(); // Register Dummy Repository

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
