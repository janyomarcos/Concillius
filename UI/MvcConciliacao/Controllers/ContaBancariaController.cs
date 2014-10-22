using Concillius.Application.Cadastros;
using Concillius.Domain.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcConciliacao.Controllers
{
    public class ContaBancariaController : Controller
    {

        ContaBancariaApplication app = null;

        public ContaBancariaController()
        {
            app = new ContaBancariaApplication();
        }

        public ActionResult Index()
        {
            var contas = app.GetAll();
            return View(contas);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new ContaBancaria());
        }

        [HttpPost]
        public ActionResult Create(ContaBancaria conta)
        {
            try
            {
                conta = Auditoria(conta);
                app.Save(conta);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ContaBancaria Auditoria(ContaBancaria conta)
        {
            conta.CodigoUsuarioInclusao = 49182;
            conta.DataInclusao = DateTime.Now;
            conta.CodigoUsuarioAlteracao = null;
            conta.DataAlteracao = null;

            return conta;
        }
        
        public ActionResult Edit(int id)
        {
            var conta = app.Get(id);
            return View(conta);
        }

        [HttpPost]
        public ActionResult Edit(int id, ContaBancaria conta)
        {
            try
            {
                app.Update(conta, id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var conta = app.Get(id);
            return View(conta);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var conta = app.Get(id);
                app.Delete(conta);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
