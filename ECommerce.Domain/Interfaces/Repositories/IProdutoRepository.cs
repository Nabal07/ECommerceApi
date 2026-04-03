using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterTodosAsync();
    Task<Produto> ObterPorIdAsync(Guid id);

}
