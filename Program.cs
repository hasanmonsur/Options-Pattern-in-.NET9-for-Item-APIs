using Microsoft.Extensions.Configuration;
using OptionMangApi.Models;
using OptionMangApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Access Configuration from the builder
var configuration = builder.Configuration;

// Register ItemApiOptions configuration

builder.Services.Configure<MyAppSettings>(configuration.GetSection("MyAppSettings"));

builder.Services.AddOptions<ItemApiOptions>()
    .Bind(configuration.GetSection("ItemApi"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

// Other service registrations
builder.Services.AddControllers();

// Register a scoped service to use IOptionsSnapshot
builder.Services.AddScoped<MyService>();

// Other service registrations
builder.Services.AddSingleton<ItemService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // Apply CORS policy

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
