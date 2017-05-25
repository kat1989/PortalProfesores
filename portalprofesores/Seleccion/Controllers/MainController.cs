using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Model;
using DataAccess.Adapter;
using Seleccion.Helpers;
namespace Seleccion.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Login()
        {
            new SessionWrapper().Id = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUserName, string txtID, string txtUserPass)
        {
            int id = 0;
            if (txtID != "")
            {
                id = SimpleSecurity.Login("", txtID, txtUserPass);
            }
            else
            {
                id = SimpleSecurity.Login(txtUserName, "", txtUserPass);
            }
                
            
            SessionWrapper session = new SessionWrapper();
            switch (id)
            {
                case -1:
                    {
                        ViewBag.Error = "No se encuentra dentro del periodo de retiro establecido.";
                        session.Id = "0";
                        break;
                    }
                case 0:
                    {
                        ViewBag.Error = "Usuario o contraseña incorrectos.";
                        session.Id = "0";
                        break;
                    }
                default:
                    {
                        JenzabarEntities entities = new JenzabarEntities();
                        new SessionWrapper().Id = id.ToString();                       

                        return RedirectToAction("Menu", "Main");
                    }
            }

            return View();
        }

        public ActionResult Menu()
        {
            if (SimpleSecurity.HasStudent())
            {
                ValidarEntrada("P");
                ValidarEntrada("R");
                ValidarEntrada("S");
                return View();
            }
            return RedirectToAction("Login", "Main");
            
        }

        public ActionResult Logout()
        {
            new SessionWrapper().Id = "";
            return View("Login");
        }

        public void ValidarEntrada(string proceso)
        {
            string error = SimpleSecurity.ValidarEntrada(proceso);

            switch (proceso)
            {
                case "P": ViewBag.ErrorPre = error != "No error" ? error : ""; break;
                case "R": ViewBag.ErrorRetiro = error != "No error" ? error : ""; break;
                case "S": ViewBag.ErrorSeleccion = error != "No error" ? error : ""; break;
            }
        }
    }
}