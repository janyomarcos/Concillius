using Concillius.Application.Cadastros;
using Concillius.Domain.Cadastros;
using Concillius.Domain.Consultas;
using MvcConciliacao.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace MvcConciliacao.Controllers
{
    public class ExportacaoAjustesController : Controller
    {

        private ExportacaoAjusteApplication app;

        public ExportacaoAjustesController()
        {
            app = new ExportacaoAjusteApplication();
        }

        public ActionResult Index()
        {
            return View(new ExportacaoAjusteViewModel());
        }

        public ActionResult Buscar(ExportacaoAjusteViewModel viewModel) 
        {
            List<ExportacaoAjusteDTO> ajustes = ObterAjustes(viewModel);
            viewModel.Itens = ajustes;
            return View(viewModel);
        }

        public ActionResult Exportar(ExportacaoAjusteViewModel viewModel) 
        {
            List<ExportacaoAjusteDTO> ajustes = ObterAjustes(viewModel);
            return View(viewModel);
        }

        private List<ExportacaoAjusteDTO> ObterAjustes(ExportacaoAjusteViewModel viewModel) 
        {
            return app.Find(x => x.DataAjuste >= viewModel.DataInicial && x.DataAjuste <= viewModel.DataFinal).ToList();
        }
        
        public ActionResult Download()
        {
            List<Filial> filiais = new List<Filial>()
            {
                new Filial(){Codigo=1},
                new Filial(){Codigo=2}
            };

            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            formatter.Serialize(memStream, filiais);

            byte[] documents = memStream.ToArray();

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "teste.csv", 
                Inline = false, 
            };
            
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(documents,"text/plain");
        }
    }
}