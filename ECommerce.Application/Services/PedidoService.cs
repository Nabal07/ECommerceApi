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

    public  async Task<List<ViewPedidoDTO>> ObterTodosAsync()
    {
        var pedidos = await _pedidoRepository.ObterTodosAsync();

        return pedidos.Select(p => new ViewPedidoDTO
        {
            Id = p.Id,
            Status = p.Status,
            DataPedido = p.DataPedido,
            CompradorId = p.CompradorId,
            Itens = p.Itens.Select(x => ViewPedidoItemDTO.Map(x)).ToList()

        }).ToList();
    }

    public async Task<ViewPedidoDTO> ObterPorIdAsync(Guid id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);

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
            Itens = pedido.Itens.Select(x => ViewPedidoItemDTO.Map(x)).ToList()
        };
    }

    public async Task CriarPedidoAsync(InputPedidoDTO dto)
    {
        var novoPedido = new Pedido(dto.IdComprador);

        foreach(var p in dto.Produtos)
        {
            var produtoDb = await _produtoService.ObterPorIdAsync(p.Id);

            if(produtoDb == null)
                throw new Exception($"O ProdutoId {p.Id} não foi encontrado.");
            

            novoPedido.AddItemPedido(produtoDb.Id);
        }

        await _pedidoRepository.CriarPedidoAsync(novoPedido);
    }

    public async Task AtualizarPedidoAsync(Guid id, EditPedidoDTO dto)
    {
        if (!Enum.IsDefined(typeof(EStatusPedido), dto.Status))
        {
            throw new InvalidOperationException($"O status {(int)dto.Status} é invalido. Use: 1(Iniciado), 2(Processado), 3(Enviado) ou 4(Cancelado).");
        }

        var pedido = await _pedidoRepository.ObterPorIdAsync(id);

        if (pedido == null) 
            throw new Exception($"Pedido com o ID {id} não encontrado.");

        pedido.AlterarStatus(dto.Status);

        await _pedidoRepository.AtualizarPedidoAsync(pedido);
    }

    public async Task ExcluirPedidoAsync(Guid id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);

        if (pedido == null)
            throw new Exception("Pedido não encontrado.");

        if (pedido.Status != EStatusPedido.Cancelado)
        {
            throw new InvalidOperationException(
                $"Não é permitido excluir um pedido com status {pedido.Status}. " +
                "Apenas pedidos 'Cancelados' podem ser removidos do sistema.");
        }

        await _pedidoRepository.ExcluirPedidoAsync(id);
    }
}
