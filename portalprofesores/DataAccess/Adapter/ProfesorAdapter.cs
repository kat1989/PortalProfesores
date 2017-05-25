using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;

namespace DataAccess.Adapter
{
    class ProfesorAdapter:AbstractAdapter<Profesor,INTEC_VW_NOMBRES_PROFESORES>
    {

        public override Profesor Transform(INTEC_VW_NOMBRES_PROFESORES dbObject)
        {
            JenzabarEntities entities = new JenzabarEntities();
 	        Profesor p = new Profesor();
            var periodo = entities.INTEC_VW_PERIODO_ACTUAL.FirstOrDefault();
            var asignaturas = entities.INTEC_VW_SECCIONES_PROFESORES
                .Where(m => m.Profesor_ID == dbObject.ID_NUM && m.ano == periodo.AnoPublicacion && m.periodo == periodo.TerminoPublicacion)
                //.OrderBy(m => new { m.seccion, m.Nombre_Asignatura }).ToList();
                .OrderBy(m => m.Nombre_Asignatura).ToList();

            p.ID = dbObject.ID_NUM;
            p.Nombre = dbObject.FIRST_NAME;
            p.Apellido = dbObject.FIRST_NAME;
            p.Tipo = dbObject.TIPO;
            p.NombreCompleto = dbObject.FIRST_NAME + " " + dbObject.MIDDLE_NAME + " " + dbObject.LAST_NAME;
            p.Trimestre = periodo.DescripcionPublicacion;            
            

            //foreach (var item in asignaturas)
            //{
            //    AsignaturaPublicacion a = new AsignaturaPublicacion();

            //    a.Codigo = item.CodigoMateria;
            //    a.CodigoCompleto = item.codigo_completo.TrimEnd();
            //    a.Ano = item.ano;
            //    a.Periodo = item.periodo;
            //    a.Seccion = item.seccion;
            //    a.Nombre = item.Nombre_Asignatura;
            //    a.NombreCompleto = item.Nombre_Asignatura;
            //    a.Retirados = item.retiros;
            //    a.Total = item.total;
            //    a.ACalificar = item.a_calificar;
            //    a.Publicados = item.publicadas;
            //    a.FechaInicio = item.inicio_publicacion;
            //    a.FechaFin = item.fin_publicacion;

            //    p.Asignaturas.Add(a);
            //}

            //p.Asignaturas.OrderByDescending(x => new { x.Nombre, x.Tipo });
            
            return p;
        }
    }
}
