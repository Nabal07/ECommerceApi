using ECommerce.Application.DTOs;

namespace ECommerce.Application.Interfaces.Services;

public interface IProdutoService
{
    Task<List<ViewProdutoDTO>> ObterTodos();
    Task<ViewProdutoDTO> ObterPorId(Guid id);
}
