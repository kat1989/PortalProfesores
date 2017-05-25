using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using DataAccess;
using Seleccion.Helpers;

namespace WebUI.Helpers
{
    public class ProfesorHelper
    {
        public static Profesor ObtenerProfesor()
        {
            int id = 0;
            int.TryParse(WrapperSession.ObtenerInstancia().Id, out id);

            var profesor = new ProfesorRepository().Find(id);
            return profesor;
        }
    }
}
