using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Cadastros
{
    public class ContaBancariaAdministradora:Entity
    {
        public int Id { get; set; }
        public int IdContaBancaria { get; set; }
        public int IdAdministradoraCartao { get; set; }
        public int IdEmpresa { get; set; }
        public string Situacao { get; set; }
    }
}
