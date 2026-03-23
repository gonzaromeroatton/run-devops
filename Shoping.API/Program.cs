
using Scalar.AspNetCore;
using Shopping.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/products", () =>
{
    var products = ProductContext.Products;

    return products;
});

app.Run();

// Asegúrate de que el paquete NuGet "Swashbuckle.AspNetCore" esté instalado en tu proyecto.
// Puedes instalarlo ejecutando el siguiente comando en la consola del Administrador de paquetes:
// Install-Package Swashbuckle.AspNetCore
 