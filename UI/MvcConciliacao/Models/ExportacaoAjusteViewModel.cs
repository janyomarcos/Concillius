using Concillius.Domain.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcConciliacao.Models
{
    public class ExportacaoAjusteViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Origem { get; set; }
        public string Contabiliza { get; set; }
        public int CodigoAdministradora { get; set; }
        public int CodigoFilial { get; set; }
        public string Tipo { get; set; }
        public string NumeroCartao { get; set; }
        public List<ExportacaoAjusteDTO> Itens;


        public ExportacaoAjusteViewModel()
        {
            Itens = new List<ExportacaoAjusteDTO>();
        }
    }
}