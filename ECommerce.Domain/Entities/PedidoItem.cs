namespace ECommerce.Domain.Entities;

public class PedidoItem
{
    public PedidoItem(Guid produtoId, Guid pedidoId)
    {
        Id = Guid.NewGuid();
        ProdutoId = produtoId;
        PedidoId = pedidoId;
    }

    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public Guid PedidoId { get; set; }
    public Produto Produto { get; set; }
    public Pedido Pedido { get; set; }
}
