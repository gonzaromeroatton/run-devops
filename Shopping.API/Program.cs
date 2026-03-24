using MongoDB.Driver;
using Scalar.AspNetCore;
using Shopping.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddScoped<ProductContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/products", async (ProductContext productContext) =>
{
    var products = await productContext.Products.Find(p => true).ToListAsync();
    return products;
});

app.Run();