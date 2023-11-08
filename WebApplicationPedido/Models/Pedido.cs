using System.ComponentModel.DataAnnotations;

namespace Pedido.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public TipoStatus Status { get; set; }
        public float? SomaTotal { get; set; }
        public enum TipoStatus
        {
            PedidoAnotado,
            EmPreparacao,
            PedidoConcluido,
            AguardandoPagamento,
            PagamentoConfirmado,
            EmProcessamento
        }
    }
}
