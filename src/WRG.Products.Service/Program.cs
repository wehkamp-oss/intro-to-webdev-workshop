using System.Text.Json.Serialization;
using WRG.Products.Service.Models;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace WRG.Products.Service;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        // Configure route options to enable regex constraints
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.SetParameterPolicy<RegexInlineRouteConstraint>("regex");
        });

        // Configure JSON serialization options
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        // Add Swagger services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Products API",
                Description = "API for managing products"
            });
        });

        var app = builder.Build();

        // Enable Swagger middleware
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API v1");
            options.RoutePrefix = "swagger"; // Set Swagger UI at /swagger
        });

        // Controller /products/
        var productsApi = app.MapGroup("/products");
        productsApi.MapGet("/", () => Results.Ok(StaticProducts.Products.List));
        productsApi.MapGet("/{productNumber}/{sizeCode}", (string productNumber, string sizeCode) =>
        {
            var product = StaticProducts.Products.List.FirstOrDefault(product =>
                product.ProductNumber == productNumber &&
                product.SizeCode == sizeCode
            );

            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        });

        app.Run();
    }
}

[JsonSerializable(typeof(IList<Product>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext;
