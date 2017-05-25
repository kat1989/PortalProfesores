using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;

namespace DataAccess.Adapter
{
    public class EstudianteAdapter: AbstractAdapter<Estudiante,INTEC_VW_PERFIL_MODULO_RETIROS>
    {
        public override Estudiante Transform(INTEC_VW_PERFIL_MODULO_RETIROS dbObject)
        {
            if (dbObject == null) return null;
            Estudiante estudiante = new Estudiante();
            Asignatura asignatura;

            estudiante.ID = dbObject.ID_NUM;
            estudiante.Matricula = dbObject.MATRICULA;
            estudiante.Nombre = dbObject.PRIMER_NOMBRE;
            estudiante.SegundoNombre = dbObject.SEGUNDO_NOMBRE;
            estudiante.Apellido = dbObject.APELLIDOS;
            estudiante.Programa = dbObject.PROGRAMA;
            estudiante.Condicion = dbObject.COND_ACADEMICA;
            estudiante.Correo = dbObject.EMAIL;
            estudiante.Division = dbObject.DIVISION;
            estudiante.TotalAsignaturasEnCurso = dbObject.TOTAL_EN_CURSO;
            estudiante.TotalAsignaturasInscritas = dbObject.TOTAL_INSCRITAS;
            estudiante.TotalAsignaturasRetiradas = dbObject.TOTAL_RETIROS;

            var dbAsignaturas = new JenzabarEntities().
                INTEC_VW_SELECION_MODULO_RETIROS.Where(m => m.ID_ESTUDIANTE == dbObject.ID_NUM);

            foreach (var item in dbAsignaturas)
            {
                asignatura = new Asignatura();

                asignatura.Calificacion = item.CALIFICACION;
                asignatura.Codigo = item.ASIGNATURA;
                asignatura.Creditos = (int) item.CREDITOS;
                asignatura.Nombre = item.DESCRIPCION;
                asignatura.Seccion = item.SECCION;
                asignatura.Fecha = item.FECHA;
                asignatura.Estatus = item.ESTATUS;
                asignatura.FechaRetiro = item.FECHA_RETIRO;

                estudiante.Asignaturas.Add(asignatura);
            }
            
            return estudiante;
        }

        public override ICollection<Estudiante> Transform(ICollection<INTEC_VW_PERFIL_MODULO_RETIROS> dbObjects)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            foreach (var item in dbObjects)
            {
                estudiantes.Add(Transform(item));
            }

            return estudiantes;
        }
    }
}
