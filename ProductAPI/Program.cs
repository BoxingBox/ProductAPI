using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DbContexts;
using ProductAPI.Logging;
using ProductAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(
    dbContextOptions => dbContextOptions.UseSqlite("Data Source=ProductAPI.db"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddTransient<ILogger, Logger<LoggingContext>>(); // ?
builder.Services.AddTransient<ILoggingContext, LoggingContext>();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
