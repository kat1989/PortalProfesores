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
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            new SessionWrapper().Id = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtUserName, string txtID, string txtUserPass)
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
                        new SessionWrapper().Id = id.ToString();
                        return RedirectToAction("Index", "Retiro");
                    }
            }

            return View();
        }
    }
}