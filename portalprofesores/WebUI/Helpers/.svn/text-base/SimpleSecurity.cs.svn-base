using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Model;
using DataAccess.Adapter;
using WebUI.Helpers;

namespace Seleccion.Helpers
{
    public static class SimpleSecurity
    {
        public static bool HaySessionActiva()
        {
            string id = WrapperSession.ObtenerInstancia().Id;
            if (String.IsNullOrEmpty(id) || id == "0")
            {
                return false;
            }
            return true;
        }

        public static int Login(string matricula, string idJenzabar, string password)
        {
            JenzabarEntities entitites = new JenzabarEntities();
            if (matricula == "" && idJenzabar == "") return 0;

            var resultId = entitites.Autenticar(idJenzabar, password);
            var id = resultId.ToList().FirstOrDefault().Value;

            return id;
        }

        public static string LoginProfesor(string username, string password)
        {
            JenzabarEntities entitites = new JenzabarEntities();

            var codigo = entitites.LoginProfesor(username, password).FirstOrDefault();

            return codigo;
        }
    }
}