using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<ECommerce.Domain.Interfaces.Repositories.IPedidoRepository, ECommerce.Infrastructure.Repositories.PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    IApplicationBuilder applicationBuilder = app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


app.MapGet("api/pedidos", async (IPedidoService service) => {
    var listaPedidos = await service.ObterTodos();

    return Results.Ok(listaPedidos);
});

app.MapGet("api/pedidos/{id}", async (Guid id, IPedidoService service) => {
    var listarPedidos = await service.ObterPorId(id);

    return Results.Ok(listarPedidos);
});

app.MapPost("api/pedidos", async (InputPedidoDTO dto, IPedidoService service) => {
    await service.CriarPedido(dto);

    return Results.Created($"/api/pedidos", dto);
});

app.MapPut("api/pedidos/{id}", () => {


    return Results.Ok();
});

app.MapDelete("api/pedidos/{id}", () => {


    return Results.Ok();
});

app.Run();