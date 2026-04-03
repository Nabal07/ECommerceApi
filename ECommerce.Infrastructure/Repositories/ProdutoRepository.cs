using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ObterTodos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<List<Produto>> ObterPorId(Guid id)
    {
        return await _context.Produtos
            .Where(p => p.Id == id)
            .ToListAsync();
    }
}
