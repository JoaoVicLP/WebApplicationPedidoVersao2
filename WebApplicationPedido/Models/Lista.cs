using System.ComponentModel.DataAnnotations;

namespace Pedido.Models
{
    public class Lista
    {
        [Key]
        public int Id { get; set; }
        public string? Status { get; set; }
        public float? SomaTotal { get; set; }
        public Mesa? Mesa { get; set; }
        public Desconto? Desconto { get; set; }
        public Taxa? Taxa { get; set; }
        public Pagamento? Pagamento { get; set; }
        public Garcom? Garcom { get; set; }
        public List<Produto>? Produtos { get; set; }
        public Cliente? Cliente { get; set; }
    }
}