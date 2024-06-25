using error_handling_in_webapi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();   // Register `Exception Filters` Globally
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
else
{
    app.UseExceptionHandler("/error");  // Redirect to a generic error handler
}

app.UseMiddleware<ExceptionHandlingMiddleware>();   // Register Global Exception Handler

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
