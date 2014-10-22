using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Concillius.Models
{

    public class LoginModel
    {
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Display(Name = "Usuário")]
        [StringLength(10)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

    }
}
