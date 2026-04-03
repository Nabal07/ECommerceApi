using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces.Services;

public interface IUsuarioService
{
    Task<List<ViewUsuarioDTO>> ObterTodosAsync();

    Task<ViewUsuarioDTO> ObterPorIdAsync(Guid id);
}
