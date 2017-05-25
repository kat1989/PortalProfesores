using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Model;
using Seleccion.Helpers;
using DataAccess;

namespace Seleccion.Classes
{
    public class SeleccionState : SeleccionAbstractState
    {
        public Estudiante CargarEstudiante()
        {
            return new EstudianteRepository().SearchById(
                new SessionWrapper().Id,
                TipoEstudiante.EstudianteSeleccion);
        }

        public string InsertarAsignatura(string codigo, int estudiante)
        {
            int id = 0;
            int.TryParse(new SessionWrapper().Id, out id);
            OfertaAcademicaRepository repository = new OfertaAcademicaRepository();

            return repository.InsertarAsignaturaSeleccion(codigo, id);
        }

        public string AgregarORemoverMateria(string codigo, string codigoCorto, int tipo, int estudiante)
        {
            var id = 0;
            OfertaAcademicaRepository repository = new OfertaAcademicaRepository();
            
            int.TryParse(new SessionWrapper().Id, out id);
            if (tipo == 0) tipo = 3;
            if (tipo == 1) tipo = 2;

            return repository.GuardarSeleccion(id, codigo, codigoCorto, tipo);
        }

        public string ModificarSeleccionTemporal(string proceso)
        {
            OfertaAcademicaRepository repository = new OfertaAcademicaRepository();
            string id = new SessionWrapper().Id;
            int intId = 0;
            int.TryParse(id, out intId);

            return repository.GuardarSeleccionTemporal(intId, proceso);
        }
    }
}