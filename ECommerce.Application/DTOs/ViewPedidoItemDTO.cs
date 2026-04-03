using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs;

public class ViewPedidoItemDTO
{
   public Guid ProdutoId { get; set; }

    public static ViewPedidoItemDTO Map(PedidoItem pedidoItem)
    {
        return new ViewPedidoItemDTO()
        {
            ProdutoId = pedidoItem.ProdutoId
        };
    }
}
