using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities;

public class Pedido
{

    public Guid Id { get; set; }
    public EStatusPedido Status { get; set; }
    public DateTime DataPedido { get; set; }

    public Guid CompradorId { get; set; }
    public Usuario Comprador { get; set; }

    public List<PedidoItem> Itens { get; set; } = new();

    public Pedido()
    {
        
    }

    public Pedido(Guid compradorId)
    {
        Id = Guid.NewGuid();
        Status = EStatusPedido.Iniciado;
        DataPedido = DateTime.Now;
        CompradorId = compradorId;
        Itens = new List<PedidoItem>();
    }

    public void AddItemPedido(Guid produtoId)
    {
        var itemPedido = new PedidoItem(Id, produtoId);
        Itens.Add(itemPedido);
    }

}