using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("frutas")]
    public class Fruta : Base
    {
        //[Column("id_categoria")]
        //public int IdCategoria { get; set; }
        //public Categoria Categoria { get; set; }

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public float Peso { get; set; }

    }
}
