using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Model;
using DataAccess.Adapter;
using Seleccion.Helpers;

namespace Seleccion.Helpers
{
    public static class SimpleSecurity
    {
        public static bool HasStudent()
        {
            string id = new SessionWrapper().Id;
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

            var resultId = entitites.Autenticar(idJenzabar, matricula, password);
            var id = resultId.ToList().FirstOrDefault().Value;

            return id;
        }

        public static string ValidarEntrada(string proceso)
        {
            JenzabarEntities entities = new JenzabarEntities();
            ErroresRepository errores = new ErroresRepository();
            SessionWrapper session = new SessionWrapper();

            var id = 0;
            int.TryParse(session.Id, out id);

            var resultId = entities.ValidarEntrada(id, proceso);
            var result = resultId.ToList().FirstOrDefault();
            var error = errores.SearchById(result.ToString()).ERR_DESC;           

            session.Id = id.ToString();

            return error != "No error" ? error : "";
        }
    }
}