using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IPedidoRepository
{
    Task<List<Pedido>> ObterTodos();

    Task<List<Pedido>> ObterPorId(Guid id);

    Task CriarPedido(Pedido dto);

    Task AtualizarPedido(Pedido dto);

    Task ExcluirPedido(Guid id);

}
