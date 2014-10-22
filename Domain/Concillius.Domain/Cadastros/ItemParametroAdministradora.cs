using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Cadastros
{
    public class ItemParametroAdministradora : Entity
    {
        public int Id { get; set; }
        public int IdParametroAdministradora { get; set; }
        public int NumeroParcela { get; set; }
        public decimal Taxa { get; set; }
    }
}
