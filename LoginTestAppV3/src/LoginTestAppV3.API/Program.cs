using LoginTestAppV3.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var _config = builder.Configuration;

// Add services to the container.

builder.Host.SerilogConfigration(_config);

builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
