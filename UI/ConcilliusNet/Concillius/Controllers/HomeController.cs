using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using Concillius.Corporativo.ApresentacaoWeb.Filtro;
//using Concillius.Corporativo.Servico.Interface;
//using Concillius.Corporativo.Apresentacao.Fabrica;
using System.Web.Security;


namespace Concillius.Controllers
{
    public class HomeController : Controller
    {

        //IAcessoServico servico;

        public HomeController()
        {
            //servico = ProxyFabrica<IAcessoServico>.Criar();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }


        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View("~/Views/Account/Login.cshtml");
        }

        //[UsuarioLogadoFiltro]
        public ActionResult Sistemas()
        {
            string usuarioLogado = "31328"; //Session["Usuario"].ToString();
            //ICollection<short> sistemas = servico.BuscarSistemasDoUsuario(usuarioLogado);

            //ViewBag.Sistemas = new List<short>(sistemas);

            return View();
        }
    
    }
}
