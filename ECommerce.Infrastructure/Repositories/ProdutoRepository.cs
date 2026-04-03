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

    public async Task<List<Produto>> ObterTodosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> ObterPorIdAsync(Guid id)
    {
        return await _context.Produtos
            .FirstOrDefaultAsync(p => p.Id == id);
            
    }
}
