using System.ComponentModel.DataAnnotations;
namespace Pedido.Models
{
    public class Garcom
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Cracha { get; set; }

    }
}