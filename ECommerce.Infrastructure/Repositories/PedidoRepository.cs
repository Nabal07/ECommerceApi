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

        public async Task<List<Pedido>> ObterTodosAsync()
        {
            return await _context.Pedidos.OrderBy(x => x.DataPedido).ToListAsync();
        }

        public async Task<Pedido> ObterPorIdAsync(Guid id)
        {   
            return await _context.Pedidos
                .Include(x => x.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task CriarPedidoAsync(Pedido dto)
        {
            _context.Pedidos.Add(dto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarPedidoAsync(Pedido dto)
        {
            _context.Pedidos.Update(dto);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirPedidoAsync(Guid id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
