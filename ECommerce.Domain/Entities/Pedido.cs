using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

public class Pedido
{
    public Guid Id { get; set; }
    public EStatusPedido Status { get; set; }
    public DateTime DataPedido { get; set; }

    public Guid IdComprador { get; set; }
    public Usuario Comprador { get; set; }

    public List<Produto> Produtos { get; set; } = new();
}