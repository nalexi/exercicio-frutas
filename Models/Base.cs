using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Base
    {
        public int Id { get; set; }
      
        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }

    }
}
