using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;
using DataAccess.Adapter;

namespace DataAccess
{
    public class ProfesorRepository
    {
        public Profesor Find(int id)
        {
            JenzabarEntities entities = new JenzabarEntities();
            var result = entities.INTEC_VW_NOMBRES_PROFESORES.FirstOrDefault(m => m.ID_NUM == id);

            return new ProfesorAdapter().Transform(result);
        }

        public string HizoEvaluacion(int? idProfesor)
        {
            var mensajeError = ""; 
            var entities = new JenzabarEntities();
            var periodo = new PeriodoRepository().RetrieveAll().FirstOrDefault();
            var codigoError = entities.ValidarEvaluacionProfesor(periodo.Ano, periodo.Termino, idProfesor).ToList().FirstOrDefault();

            if (codigoError != "Y")
            {
                mensajeError = new ErroresRepository().SearchById(codigoError).ERR_DESC;
            }

            return mensajeError;
        }
    }
}
