using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seleccion.Controllers;
using DataAccess.Model;

namespace Seleccion.Classes
{
    public interface SeleccionAbstractState
    {
        Estudiante CargarEstudiante();
        string InsertarAsignatura(string codigo, int estudiante);
        string AgregarORemoverMateria(string codigo, string codigoCorto, int tipo, int estudiante);
        string ModificarSeleccionTemporal(string proceso);
    }
}