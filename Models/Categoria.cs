using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("categorias")]
    public class Categoria : Base
    {
        [Column("nome_categoria")]
        public string NomeCategoria { get; set; }

        


    }
}
