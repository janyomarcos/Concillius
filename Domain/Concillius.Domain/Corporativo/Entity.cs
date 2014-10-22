using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Corporativo
{
    public class Entity
    {
        public int CodigoUsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }
        public int Versao { get; set; }
        public int? CodigoUsuarioAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
