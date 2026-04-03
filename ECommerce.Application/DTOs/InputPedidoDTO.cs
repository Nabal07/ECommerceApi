using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs;

public class InputPedidoDTO
{
    public Guid IdComprador { get; set; }
    public List<InputProdutoDTO> Produtos { get; set; } = new();

}
