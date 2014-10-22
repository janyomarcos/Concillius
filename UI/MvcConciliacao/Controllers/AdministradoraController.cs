using Concillius.Application.Cadastros;
using Concillius.Application.Corporativo;
using Concillius.Domain.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcConciliacao.Controllers
{
    public class AdministradoraController : Controller
    {

        AdministradoraCartaoApplication app = null;

        public AdministradoraController()
        {
            app = new AdministradoraCartaoApplication();
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
            return View(new AdministradoraCartao());
        }

        [HttpPost]
        public ActionResult Create(AdministradoraCartao admin)
        {
            try
            {
                app.Save(admin);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id, int idEmpresa)
        {
            var admin = app.Get(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult Edit(int id, int idEmpresa, AdministradoraCartao admin)
        {
            try
            {
                app.Update(admin, id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id, int idEmpresa)
        {
            var admin = app.Get(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult Delete(int id, int idEmpresa, FormCollection collection)
        {
            try
            {
                var admin = app.Get(id);
                app.Delete(admin);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
