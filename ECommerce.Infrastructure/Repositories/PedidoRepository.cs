using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> ObterTodos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<List<Pedido>> ObterPorId(Guid id)
        {
            return await _context.Pedidos
                .Where(p => p.Id == id)
                .ToListAsync();
        }
        public async Task CriarPedido(Pedido dto)
        {
            _context.Pedidos.Add(dto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarPedido(Pedido dto)
        {
            throw new NotImplementedException();
        }

        public async Task ExcluirPedido(Guid id)
        {
            throw new NotImplementedException();
        }

       
    }
}
