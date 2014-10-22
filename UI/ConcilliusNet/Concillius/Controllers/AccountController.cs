using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Concillius.Models;
using Microsoft.Http;
using System.Xml;
using System.Configuration;

namespace Concillius.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
                

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (DadosAutenticos(model))
                {
                    int versao = 1;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(versao,
                                                                                    model.Usuario,
                                                                                    DateTime.Now,
                                                                                    DateTime.Now.AddMinutes(30),
                                                                                    true,
                                                                                    model.Usuario,
                                                                                    FormsAuthentication.FormsCookiePath);

                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    return RedirectToAction("Sistemas", "Home");

                }
                else 
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Usuário e senha incorretos.");
                    return View(model);
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }


        private ActionResult ContextDependentView()
        {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null)
            {
                ViewBag.FormAction = "Json" + actionName;
                return PartialView();
            }
            else
            {
                ViewBag.FormAction = actionName;
                return View();
            }
        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }


        private Boolean DadosAutenticos(LoginModel model)
        {
            if (model.Usuario.Equals("roberto") && model.Senha.Equals("ana"))
            {
                return true;
            }
            else 
            {
                return false;
            }

            
            //var http = new HttpClient();
            //var xml = new XmlDocument();
            //var baseAddress = ConfigurationManager.AppSettings["UrlServicoAutenticacao"];
            //var uri = new Uri( baseAddress + "?matricula=" + model.Usuario + "&senha=" + HttpUtility.UrlEncode(model.Senha) + "&app=INET") ;
       
            //xml.Load(http.Get(uri).Content.ReadAsXmlReader());

            //if (!xml.SelectSingleNode("com.pmenos.cosmos.servicosretaguarda.controle.servico.rs.RespostaPadraoRest").LastChild.InnerText.ToUpper().Equals("OK"))
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

        }
    

    }
}
