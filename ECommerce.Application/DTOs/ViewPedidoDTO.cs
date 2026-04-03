using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class ViewPedidoDTO
    {
        public Guid Id { get; set; }
        public EStatusPedido Status { get; set; }
        public DateTime DataPedido { get; set; }

        public Guid CompradorId { get; set; }
        public List<ViewPedidoItemDTO> Itens { get; set; } = new();
    }
}
