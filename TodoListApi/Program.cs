using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseSwaggerUI(options =>
{
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint("openapi/v1.json", "Todo List API");
});

var todosList = new List<Todos>();

app.MapGet("/api/todos", () => Results.Ok(todosList));
app.MapGet("/api/todos/{id:int}", (int id) =>
{
    return todosList.Find(x => x.Id == id);
});
app.MapPost("/api/addtodos", ([FromBody] Todos newTodo) =>
{
    if (todosList.Any(x => x.Id == newTodo.Id))
    {
        return Results.BadRequest("A todo with the same ID already exists");
    }
    todosList.Add(newTodo);
    return Results.Created($"/api/todos/{newTodo.Name}", newTodo);
});

app.Run();

//Record is immutable by default
record Todos(
    int Id,
    [Required] string Name,
    [Required] string Description,
    [Required] bool IsDone
);