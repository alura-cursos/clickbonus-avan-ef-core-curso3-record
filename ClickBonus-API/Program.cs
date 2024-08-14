using ClickBonus_API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ClickBonusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.Run();


