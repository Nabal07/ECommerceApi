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

    public void AlterarStatus(EStatusPedido novoStatus)
    {
        if (novoStatus == EStatusPedido.Processado && Status != EStatusPedido.Iniciado)
            throw new InvalidOperationException("Apenas pedidos iniciados podem ser processados.");

        if (novoStatus == EStatusPedido.Cancelado &&
            Status != EStatusPedido.Iniciado && Status != EStatusPedido.Processado)
            throw new InvalidOperationException("Apenas pedidos iniciados ou processados podem ser cancelados.");

        if (novoStatus == EStatusPedido.Enviado && Status != EStatusPedido.Processado)
            throw new InvalidOperationException("Apenas pedidos processados podem ser enviados.");
        
        if (Status == EStatusPedido.Cancelado)
            throw new InvalidOperationException("Um pedido cancelado não pode mais ser alterado.");

        Status = novoStatus;
    }

}