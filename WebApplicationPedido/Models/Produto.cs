using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedido.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float PrecoUnit { get; set; }
        public float PrecoTotal { get; set; }
        public string? Observacao { get; set; }
        public List<Condimento>? Condimento { get; set; }

    }
}
