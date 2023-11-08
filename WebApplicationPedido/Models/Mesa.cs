using System.ComponentModel.DataAnnotations;

namespace Pedido.Models
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public string? Disponibilidade { get; set; }

    }

}
