using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Cadastros
{
    public class AdministradoraCartao:Entity
    {
        public int Id { get; set; }
        public string NomeCartao { get; set; }
        public int IdEmpresa { get; set; }
        public string TipoCartao { get; set; }
        public int NumeroMaximoParcelas { get; set; }
        public decimal? CodigoControle { get; set; }
        public int? CodigoLayout { get; set; }
        public string NomePasta { get; set; }
        public int? CodigoUsuarioResponsavel { get; set; }
        public decimal? DiaMesCredito { get; set; }
        public string SomarFeriado { get; set; }
        public string ImportarAntecipacao { get; set; }
        public int? CodigoCliente { get; set; }
        public int? IdRegraGerarVencimento { get; set; }
        public string ImportarArquivoVencimentoFinanceiroJuntos { get; set; }
        public string Situacao { get; set; }
        public string DuplicarCarga { get; set; }
        public string ImportaAjusteFinanceiro { get; set; }
        public string ImportaAjusteVenda { get; set; }
        public string Gerar { get; set; }
        public int? TipoUniao { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
    }
}
