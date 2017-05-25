using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Model;
using DataAccess;
using Seleccion.Helpers;

namespace Seleccion.Classes
{
    public class PreseleccionState : SeleccionAbstractState
    {
        public Estudiante CargarEstudiante()
        {
            return new EstudianteRepository().SearchById(
                new SessionWrapper().Id,
                TipoEstudiante.EstudiantePreseleccion);
        }

        public string InsertarAsignatura(string codigo, int estudiante)
        {
            int id = 0;
            int.TryParse(new SessionWrapper().Id, out id);
            OfertaAcademicaRepository repository = new OfertaAcademicaRepository();

            repository.InsertarAsignatura(codigo, id);
            return "NO";
        }

        public string AgregarORemoverMateria(string codigo, string codigoCorto, int tipo, int estudiante)
        {
            JenzabarEntities entities = new JenzabarEntities();
            var reg = entities.TW_REG_CONFIG.FirstOrDefault(m => m.TEL_WEB_REG_CDE == "W");
            var id = 0;
            int.TryParse(new SessionWrapper().Id, out id);

            entities.GuardarSeleccion(
                id,
                codigo,
                codigoCorto,
                reg.DFLT_YR_CDE,
                reg.DFLT_TRM_CDE,
                tipo);
            return "NO";
        }

        public string ModificarSeleccionTemporal(string proceso)
        {
            JenzabarEntities entities = new JenzabarEntities();
            string id = new SessionWrapper().Id;
            int intId = 0;
            int.TryParse(id, out intId);

            entities.GuardarPreseleccionTemporal(intId, proceso);
            return "";
        }
    }
}