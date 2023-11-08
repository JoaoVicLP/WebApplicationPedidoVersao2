using System.ComponentModel.DataAnnotations;

namespace Pedido.Models
{
    public class Taxa
    {
        [Key]
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public float Valor { get; set; }
    }
}
