using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces.Services;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Interfaces.Repositories;

namespace ECommerce.Application.Services;

public class PedidoService : IPedidoService
{

    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoService _produtoService;

    public PedidoService(IPedidoRepository pedidoRepository, IProdutoService produtoService)
    {
        _pedidoRepository = pedidoRepository;
        _produtoService = produtoService;
    }



    public async Task<List<ViewPedidoDTO>> ObterTodos()
    {
        var pedidos = await _pedidoRepository.ObterTodos();

        return pedidos.Select(p => new ViewPedidoDTO
        {
            Id = p.Id,
            Status = p.Status,
            DataPedido = p.DataPedido,
            CompradorId = p.CompradorId,
            Itens = p.Itens
        }).ToList();
    }

    public async Task<ViewPedidoDTO> ObterPorId(Guid id)
    {
        var pedidos = await _pedidoRepository.ObterPorId(id);

        var pedido = pedidos.FirstOrDefault();

        if (pedido == null)
        {
            throw new Exception($"Pedido com o ID {id} não foi encontrado.");
        }

        return new ViewPedidoDTO
        {
            Id = pedido.Id,
            Status = pedido.Status,
            DataPedido = pedido.DataPedido,
            CompradorId = pedido.CompradorId,
            Itens = pedido.Itens
        };
    }
    public async Task CriarPedido(InputPedidoDTO dto)
    {
        var novoPedido = new Pedido(dto.IdComprador);

        foreach(var p in dto.Produtos)
        {
            var produtoDb = await _produtoService.ObterPorId(p.Id);

            novoPedido.AddItemPedido(produtoDb.Id);
        }

        await _pedidoRepository.CriarPedido(novoPedido);
    }

    public async Task<List<ViewPedidoDTO>> AtualizarPedido(EditPedidoDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task ExcluirPedido(Guid id)
    {
        throw new NotImplementedException();
    }

    
}
