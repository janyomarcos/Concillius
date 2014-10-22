using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcConciliacao.Controllers
{
    public class FilialController : Controller
    {
        //
        // GET: /Filial/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Filial/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Filial/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Filial/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Filial/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Filial/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Filial/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Filial/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
