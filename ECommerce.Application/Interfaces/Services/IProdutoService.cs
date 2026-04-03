using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces.Services;

public interface IProdutoService
{
    Task<List<ViewProdutoDTO>> ObterTodosAsync();
    Task<ViewProdutoDTO> ObterPorIdAsync(Guid id);
}
