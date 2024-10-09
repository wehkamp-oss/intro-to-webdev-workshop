using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace WRG.Products.Combinations.Service;
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

        var sampleTodos = new Todo[] {
            new(1, "Walk the dog"),
            new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
            new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
            new(4, "Clean the bathroom"),
            new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
        };

        // Controllers
        var todosApi = app.MapGroup("/todos");
        todosApi.MapGet("/", () => sampleTodos);
        todosApi.MapGet("/{id}", (int id) =>
            sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
                ? Results.Ok(todo)
                : Results.NotFound());

        app.Run();
    }
}

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
