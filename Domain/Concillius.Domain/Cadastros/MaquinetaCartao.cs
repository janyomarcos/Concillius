using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Cadastros
{
    public class MaquinetaCartao : Entity
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int IdAdministradora { get; set; }
        public int CodigoEmpresa { get; set; }
        public int? CodigoFilial { get; set; }
        public string Situacao { get; set; }
        public string Tipo { get; set; }
        public string ImportarCupomDetalhado { get; set; }
        public string GravarCupom { get; set; }
        public int? NumeroTerminal { get; set; }
    }
}
