using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces.Services;

public interface IPedidoService
{
    Task <List<ViewPedidoDTO>> ObterTodosAsync();

    Task<ViewPedidoDTO> ObterPorIdAsync(Guid id);

    Task CriarPedidoAsync(InputPedidoDTO dto);

    Task AtualizarPedidoAsync(Guid id, EditPedidoDTO dto);

    Task ExcluirPedidoAsync(Guid id);

}
