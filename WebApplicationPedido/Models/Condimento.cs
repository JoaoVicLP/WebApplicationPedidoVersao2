using System.ComponentModel.DataAnnotations;

namespace Pedido.Models
{
    public class Condimento
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float Quantidade { get; set; }
    }

}
