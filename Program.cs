using Microsoft.Extensions.Configuration;
using OptionMangApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Access Configuration from the builder
var configuration = builder.Configuration;

// Register ItemApiOptions configuration

//builder.Services.Configure<ItemApiOptions>(configuration.GetSection("ItemApi"));

builder.Services.AddOptions<ItemApiOptions>()
    .Bind(configuration.GetSection("ItemApi"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

// Other service registrations
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

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
