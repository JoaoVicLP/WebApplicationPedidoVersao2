using System.ComponentModel.DataAnnotations;

namespace Pedido.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }
        public string? Formadepagamento { get; set; }

    }
}
