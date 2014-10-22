using Concillius.Domain.Corporativo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concillius.Domain.Cadastros
{
    public class ContaBancaria:Entity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Código Banco")]
        public int CodigoBanco { get; set; }

        [Required]
        [Display(Name = "Código Agência")]
        public int CodigoAgencia { get; set; }

        [Required]
        [Display(Name = "Código Empresa")]
        public int CodigoEmpresa { get; set; }

        [Required]
        [Display(Name = "Código Conta")]
        public decimal CodigoConta { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Conta Web")]
        public string ContaWeb { get; set; }

        [Required]
        [Display(Name = "Conta Contabil")]
        public string ContaContabil { get; set; }

        [Required]
        [Display(Name = "Situação")]
        public string Situacao { get; set; }
    }
}
