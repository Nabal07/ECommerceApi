namespace ECommerce.Domain.Entities;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public List<Pedido> Pedidos { get; set; } = new();
}