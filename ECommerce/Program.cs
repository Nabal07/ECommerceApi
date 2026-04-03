using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Application.Services;
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
builder.Services.AddScoped<ECommerce.Domain.Interfaces.Repositories.IProdutoRepository, ECommerce.Infrastructure.Repositories.ProdutoRepository>();
builder.Services.AddScoped<ECommerce.Domain.Interfaces.Repositories.IUsuarioRepository, ECommerce.Infrastructure.Repositories.UsuarioRepository>();

builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    IApplicationBuilder applicationBuilder = app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapGet("api/v1/usuarios", async (IUsuarioService service) => {
    var listaUsuarios= await service.ObterTodosAsync();

    return Results.Ok(listaUsuarios);
});

app.MapGet("api/v1/produtos", async (IProdutoService service) => {
    var listaProdutos = await service.ObterTodosAsync();

    return Results.Ok(listaProdutos);
});

app.MapGet("api/v1/pedidos", async (IPedidoService service) => {
    var listaPedidos = await service.ObterTodosAsync();

    return Results.Ok(listaPedidos);
});

app.MapGet("api/v1/pedidos/{id}", async (Guid id, IPedidoService service) => {
    
    var pedido = await service.ObterPorIdAsync(id);

    if(pedido == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(pedido);
});

app.MapPost("api/v1/pedidos", async (InputPedidoDTO dto, IPedidoService service) => {
    await service.CriarPedidoAsync(dto);

    return Results.Created($"/api/pedidos", dto);
});

app.MapPut("api/v1/pedidos/{id}", async (Guid id, EditPedidoDTO dto, IPedidoService service) => {
    try
    {
        await service.AtualizarPedidoAsync(id, dto);
        return Results.NoContent();
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(new { mensagem = ex.Message });
    }
});
app.MapDelete("api/v1/pedidos/{id}", async (Guid id, IPedidoService service) => {
    try
    {
        await service.ExcluirPedidoAsync(id);
        return Results.NoContent(); 
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(new { mensagem = ex.Message });
    }
});

app.Run();