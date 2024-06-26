using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register for API Versioning using URL Path
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;   // Report API versions in responses
    options.AssumeDefaultVersionWhenUnspecified = true;     // Assume default version when not specified
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);  // Set the default API version to 1.0
});

// Register for API Versioning using Query String
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ApiVersionReader = new QueryStringApiVersionReader("v");
});

/*
    Specify the API Version in the header:

    FOR Version 1.0 ----------------------
    
    GET /api/products HTTP/1.1
    Host: localhost:5001
    x-api-version: 1.0

    For Version 2.0 ----------------------

    GET /api/products HTTP/1.1
    Host: localhost:5001
    x-api-version: 2.0

 */

// Register for API Versioning using Media Type Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ApiVersionReader = new MediaTypeApiVersionReader();
});

/*
    Specify the API Version in the header:

    For Version 1.0 -------------------------

    GET /api/products HTTP/1.1
    Host: localhost:5001
    Accept: application/json;v=1.0

    For Version 2.0 -------------------------

    GET /api/products HTTP/1.1
    Host: localhost:5001
    Accept: application/json;v=2.0

*/

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
