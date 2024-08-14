using ClickBonus_API.Context;
using ClickBonus_API.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ClickBonusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
    new MongoClient("mongodb://localhost:27017"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/hello", () =>
{   
    return Results.Ok("Click Bonus! Cadastra-se e concorra.");
})
.WithTags("helloworld")
.WithOpenApi();

app.MapGet("/api/usuarios", async ([FromServices] ClickBonusContext context) =>
{
    var usuarios = await context.Usuarios.ToListAsync();
    return Results.Ok(usuarios);
});

app.MapGet("/api/bonus", (IMongoClient mongoClient) =>
{
    var dbContextOptions = new DbContextOptionsBuilder<ClickBonusMongoDBContext>().UseMongoDB(mongoClient, "db_Clickbonus");
    var db = new ClickBonusMongoDBContext(dbContextOptions.Options);

    return Results.Ok(db.Bonuses.ToList());

}).WithTags("Bonus")
.WithOpenApi();

app.MapPost("/api/bonus", (IMongoClient mongoClient, [FromBody] Bonus bonus) =>
{
    var dbContextOptions = new DbContextOptionsBuilder<ClickBonusMongoDBContext>().UseMongoDB(mongoClient, "db_Clickbonus");
    var db = new ClickBonusMongoDBContext(dbContextOptions.Options);
    db.Bonuses.Add(bonus);
    db.SaveChanges();
    return Results.Ok(bonus);

}).WithTags("Bonus")
.WithOpenApi();


app.Run();


