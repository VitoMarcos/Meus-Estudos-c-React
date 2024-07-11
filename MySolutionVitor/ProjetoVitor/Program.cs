using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Carros.Models;
using Banco.Models;

var builder = WebApplication.CreateBuilder(args);
// Registrar o serviço de banco de dados
builder.Services.AddDbContext<AppDataContext>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Habilitar o uso do CORS
app.UseCors("AllowAll");

app.MapGet("/", () => "Minha API de estudo");

app.MapGet("/Carro/Listar", ([FromServices] AppDataContext ctx) => {
    if (ctx.carritos.Any())
    {
        return Results.Ok(ctx.carritos.ToList());
    }
    return Results.NotFound("Não existem carros na tabela");
});

app.MapPost("/Carro/Cadastrar", ([FromBody] Carro newCarro, [FromServices] AppDataContext ctx) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(newCarro, new ValidationContext(newCarro), erros, true))
    {
        return Results.BadRequest(erros);
    }

    Carro? carroEncontrado = ctx.carritos.FirstOrDefault(x => x.Modelo == newCarro.Modelo);
    if (carroEncontrado is null)
    {
        ctx.carritos.Add(newCarro);
        ctx.SaveChanges();
        return Results.Created("", newCarro);
    }
    return Results.BadRequest("Já existe um carro com o mesmo nome");
});

app.MapDelete("/Carro/Deletar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    Carro? c = ctx.carritos.FirstOrDefault(x => x.Id == id);
    if (c is null)
    {
        return Results.NotFound("Automóvel não encontrado!");
    }
    ctx.carritos.Remove(c);
    ctx.SaveChanges();
    return Results.Ok("Automóvel deletado!");
});

app.MapGet("/Carro/Procurar/{modelo}", ([FromRoute] string modelo, [FromServices] AppDataContext ctx) =>
{
    Carro? c = ctx.carritos.FirstOrDefault(x => x.Modelo == modelo);
    if (c is null)
    {
        return Results.NotFound("Carro não encontrado!");
    }
    return Results.Ok(c);
});

app.MapPut("/Carro/Alterar/{id}", ([FromRoute] string id, [FromBody] Carro carroAlterado, [FromServices] AppDataContext ctx) =>
{
    Carro? c = ctx.carritos.FirstOrDefault(x => x.Id == id);
    if (c is null)
    {
        return Results.NotFound("Automóvel não encontrado!");
    }
    c.Marca = carroAlterado.Marca;
    c.Modelo = carroAlterado.Modelo;
    c.Ano = carroAlterado.Ano;
    ctx.carritos.Update(c);
    ctx.SaveChanges();
    return Results.Ok("Carro alterado!");
});

app.Run();

//DICAS DE OURO: 
//dotnet add package Microsoft.AspNetCore.Cors
//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet add package Microsoft.EntityFrameworkCore.Sqlite
//dotnet ef migrations add InitialCreate
//dotnet ef database update
