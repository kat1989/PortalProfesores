using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Model;
using DataAccess.Adapter;
using Seleccion.Helpers;
using System.Net;
using System.IO;
using System.Configuration;
using WebUI.Helpers;
using Logger;

namespace Seleccion.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Login()
        {
            try
            {
                WrapperSession.ObtenerInstancia().Id = "0";
            }
            catch (Exception ex)
            {
                EventLogger logger = new EventLogger("SiteProfesores");
                string information = "";
                information += "Ubicacion: Main/Login \n";
                information += "Id Profesor:" + WrapperSession.ObtenerInstancia().Id+ "\n";
                information += "Error: " + ex.Message + "\n";
                information += "Inner Exception: " + ex.InnerException + "\n";
                if (ex.InnerException != null)
                    information += "Inner Exception Messaje: " + ex.InnerException.Message + "\n";
                information += "Stack Trace: " + ex.StackTrace + "\n";

                logger.Error(information);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtID, string txtUserPass)
        {
            try
            {
                string result = SimpleSecurity.LoginProfesor(txtID, txtUserPass);

                WrapperSession session = WrapperSession.ObtenerInstancia();
                if (result == "N")
                {
                    ViewBag.Error = "Usuario o contraseña incorrectos.";
                    session.Id = "0";
                    return View();
                }
                else
                {
                    int id = 0;
                    int.TryParse(txtID, out id);
                    WrapperSession.ObtenerInstancia().TipoProfesor = new ProfesorRepository().Find(id).Tipo;
                    session.Id = txtID;
                }
            }
            catch (Exception ex)
            {
                EventLogger logger = new EventLogger("SiteProfesores");
                string information = "";
                information += "Ubicacion: Main/Login \n";
                information += "Id Profesor:" + WrapperSession.ObtenerInstancia().Id + "\n";
                information += "Error: " + ex.Message + "\n";
                information += "Inner Exception: " + ex.InnerException + "\n";
                if (ex.InnerException != null)
                    information += "Inner Exception Messaje: " + ex.InnerException.Message + "\n";
                information += "Stack Trace: " + ex.StackTrace + "\n";

                logger.Error(information);
            }
            return RedirectToAction("Inicio", "Main");
            
        }

        public ActionResult Inicio()
        {
            if (SimpleSecurity.HaySessionActiva())
            {
                try
                {
                    //ValidarEntrada("P");
                    //ValidarEntrada("R");
                    //ValidarEntrada("S");
                    return View();
                }
                catch (Exception ex)
                {
                    EventLogger logger = new EventLogger("SiteProfesores");
                    string information = "";
                    information += "Ubicacion: Main/Inicio \n";
                    information += "Id Profesor:" + WrapperSession.ObtenerInstancia().Id + "\n";
                    information += "Error: " + ex.Message + "\n";
                    information += "Inner Exception: " + ex.InnerException + "\n";
                    if (ex.InnerException != null)
                        information += "Inner Exception Messaje: " + ex.InnerException.Message + "\n";
                    information += "Stack Trace: " + ex.StackTrace + "\n";

                    logger.Error(information);
                    return RedirectToAction("Login", "Main");
                }
            }
            else
            {
                TempData["Timeout"] = true;
                return RedirectToAction("Login", "Main");
            }
        }

        public ActionResult Logout()
        {
            try
            {
                WrapperSession.ObtenerInstancia().Id = "";
            }
            catch (Exception ex)
            {
                EventLogger logger = new EventLogger("SiteProfesores");
                string information = "";
                information += "Ubicacion: Main/LogOut \n";
                information += "Id Profesor:" + WrapperSession.ObtenerInstancia().Id + "\n";
                information += "Error: " + ex.Message + "\n";
                information += "Inner Exception: " + ex.InnerException + "\n";
                if (ex.InnerException != null)
                    information += "Inner Exception Messaje: " + ex.InnerException.Message + "\n";
                information += "Stack Trace: " + ex.StackTrace + "\n";

                logger.Error(information);
            }
            return View("Login");
        }
    }
}
