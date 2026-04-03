using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{

    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> ObterTodos()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<List<Usuario>> ObterPorId(Guid id)
    {
        return await _context.Usuarios
            .Where(u => u.Id == id)
            .ToListAsync();
    }
}
