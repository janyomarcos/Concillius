using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Consultas
{
    public class ExportacaoAjusteDTO
    {
        public int CodigoAdministradora { get; set; }
        public string NomeAdministradora { get; set; }
        public DateTime DataAjuste { get; set; }
        public int CodigoFilial { get; set; }
        public string NumeroCartao { get; set; }
        public string Origem { get; set; }
        public string Tipo { get; set; }
        public string Contabiliza { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public string Motivo { get; set; }
    }
}
