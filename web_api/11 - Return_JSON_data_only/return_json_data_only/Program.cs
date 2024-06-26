using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Configure JSON serializer settings
                    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

// Optional: To remove other formatters like XML, you can configure it explicitly
builder.Services.Configure<MvcOptions>(options =>
{
    // Remove the XML formatter if it's added by default
    var xmlFormatter = options.OutputFormatters.OfType<Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter>().FirstOrDefault();
    if (xmlFormatter != null)
    {
        options.OutputFormatters.Remove(xmlFormatter);
    }
});
    
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
