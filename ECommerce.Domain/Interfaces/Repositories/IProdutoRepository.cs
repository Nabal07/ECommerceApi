using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IProdutoRepository
{
    Task<List<Produto>> ObterTodos();
    Task<List<Produto>> ObterPorId(Guid id);

}
