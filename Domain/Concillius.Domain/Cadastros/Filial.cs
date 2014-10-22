using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Cadastros
{
    public class Filial:Entity
    {
        public int Codigo { get; set; }
        public int CodigoEmpresa { get; set; }
        public string NomeFilial { get; set; }
        public int? CodigoFilialERP { get; set; }
        public string Endereco { get; set; }
        public string NumeroLogradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string CGC { get; set; }
        public DateTime? DataAbertura { get; set; }
        public string Sigla { get; set; }
    }
}
