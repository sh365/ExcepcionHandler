using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHandleException.Models;
using MvcHandleException.Filtro;

namespace MvcHandleException.Controllers
{
    public class SampleErrorController : Controller
    {
        Usuario us;
        public SampleErrorController()
        {
            us = new Usuario { usuario = "usuariocorrecto", password = "12345" };
        }

        public ActionResult Login()
        {
            return View();
        }

        [ExcepcionPersonalizada]
        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {
            if(usuario == "" || password == "")
            {
                throw new Exception("Usuario/Password vacio");
            }
            else if(usuario != us.usuario || password != us.password)
            {
                throw new Exception("Usuario/Password incorrecto");
            }
            return View();
        }

        public ActionResult Error(string msg)
        {
            ViewBag.Mensaje = msg;
            return View();
        }
    }
}