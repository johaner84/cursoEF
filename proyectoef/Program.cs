using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(a=>a.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConexion",async ([FromServices] TareasContext context ) =>
{
    context.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria "+context.Database.IsInMemory());
});

app.Run();
