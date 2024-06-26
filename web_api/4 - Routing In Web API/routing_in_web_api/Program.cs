var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseRouting();                   // Defining Conventional Routing

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>       // Defining Conventional Routing
{
    endpoints.MapControllerRoute(
        name: "defaut",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllers();

app.Run();
