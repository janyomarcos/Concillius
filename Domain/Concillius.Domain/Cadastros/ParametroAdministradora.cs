using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Cadastros
{
    public class ParametroAdministradora : Entity
    {
        public int Id { get; set; }
        public List<ItemParametroAdministradora> Itens { get; set; }
        public int? IdAdministradora { get; set; }
        public int? CodigoEmpresa { get; set; }
        public DateTime DataVigencia { get; set; }
        public int QuantidadeDiasRotativo { get; set; }
        public int? QuantidadeDiasParcelado { get; set; }
        public int? QuantidadeDiasParcela1 { get; set; }
        public decimal ValorDocumento { get; set; }
        public int DiaSemanaCredito { get; set; }
        public string MesCredito { get; set; }
        public string DataParcela1 { get; set; }
        public decimal? ValorSaldoInicial { get; set; }
        public string BaseParcelaAnterior { get; set; }
        public string DiasAdministracaoTrafego { get; set; }
        public string MesAnterior { get; set; }
        public string Desativado { get; set; }

    }
}
