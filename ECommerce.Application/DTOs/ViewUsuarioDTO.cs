using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs;

public class ViewUsuarioDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public List<Pedido> Pedidos { get; set; }
}
