using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<List<Usuario>> ObterTodosAsync();
    Task<Usuario> ObterPorIdAsync(Guid id);
}
