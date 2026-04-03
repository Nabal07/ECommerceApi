using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces.Services;

public interface IPedidoService
{
    Task <List<ViewPedidoDTO>> ObterTodos();

    Task<ViewPedidoDTO> ObterPorId(Guid id);

    Task CriarPedido(InputPedidoDTO dto);

    Task<List<ViewPedidoDTO>> AtualizarPedido(EditPedidoDTO dto);

    Task ExcluirPedido(Guid id);

}
