using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ObterTodos();
    Task<List<Usuario>> ObterPorId(Guid id);
}
