using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IPedidoRepository
{
    Task<List<Pedido>> ObterTodosAsync();

    Task<Pedido> ObterPorIdAsync(Guid id);

    Task CriarPedidoAsync(Pedido dto);

    Task AtualizarPedidoAsync(Pedido dto);

    Task ExcluirPedidoAsync(Guid id);

}
