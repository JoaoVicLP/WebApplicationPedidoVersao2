using System.ComponentModel.DataAnnotations;

namespace Pedido.Models
{
    public class Desconto
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float Valor { get; set; }

    }
}
