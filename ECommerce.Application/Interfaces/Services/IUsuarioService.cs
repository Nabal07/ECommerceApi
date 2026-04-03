using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces.Services;

public interface IUsuarioService
{
    Task<List<ViewUsuarioDTO>> ObterTodos();

    Task<ViewUsuarioDTO> ObterPorId(Guid id);
}
