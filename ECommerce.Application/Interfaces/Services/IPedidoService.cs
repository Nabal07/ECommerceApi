using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services;

public interface IPedidoService
{
    //200
    Task <List<ViewPedidoDTO>> ObterTodos();
    //200
    Task<ViewPedidoDTO> ObterPorId(Guid id);

    //201
    Task CriarPedido(InputPedidoDTO dto);

    //204
    Task<List<ViewPedidoDTO>> AtualizarPedido(EditPedidoDTO dto);

    //200
    Task ExcluirPedido(Guid id);

}
