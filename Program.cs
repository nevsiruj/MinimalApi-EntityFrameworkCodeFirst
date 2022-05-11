using ApiC03;
using ApiC03.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<DisneyDb>(opt => opt.UseInMemoryDatabase("DisneyDb"));

// Add services to the container.
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

// Personajes



app.MapPost("/characters", async (Personaje personaje, DisneyDb db) =>
{
    db.Personajes.Add(personaje);
    await db.SaveChangesAsync();

    return Results.Created($"/characters/{personaje.Id}", personaje);
});

app.MapGet("/characters", async (DisneyDb db) =>
    await db.Personajes.ToListAsync());





app.MapPut("/characters/{id}", async (int id, Personaje inputPersonaje, DisneyDb db) =>
{
    var personaje = await db.Personajes.FindAsync(id);

    if (personaje is null) return Results.NotFound();

    personaje.Name = inputPersonaje.Name;
    personaje.Edad = inputPersonaje.Edad;

    await db.SaveChangesAsync();

    return Results.NoContent();

});



app.MapDelete("/characters/{id}", async (int id, DisneyDb db) =>
{
    if (await db.Personajes.FindAsync(id) is Personaje personaje)
    {
        db.Personajes.Remove(personaje);
        await db.SaveChangesAsync();
        return Results.Ok(personaje);
    }

    return Results.NotFound();
});

//app.MapGet("/perros/{id}", async (int id, PerroDb db) =>
//    await db.Perros.FindAsync(id)
//        is Perro todo
//            ? Results.Ok(todo)
//            : Results.NotFound());

app.Run();
