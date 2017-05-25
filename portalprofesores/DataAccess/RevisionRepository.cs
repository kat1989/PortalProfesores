using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DataAccess.Model;


namespace DataAccess
{
    public class RevisionRepository : IDisposable
    {
        private readonly BaseRepository<Revision> _revisionDataAccess;
        private readonly BaseRepository<Asignatura> _asignaturaDataAccess;
        private BaseRepository<EstadoRevision> _estadoRevisionDataAccess;
        private BaseRepository<ElementoFiltro> _elementoFiltrDataAccess;
        private BaseRepository<Persona> _personaDataAccess;
        private BaseRepository<Ciclo> _cicloDataAccess;

        private bool _disposing;



        public RevisionRepository()
        {
            _revisionDataAccess = new BaseRepository<Revision>();
            _asignaturaDataAccess = new BaseRepository<Asignatura>();
        }

        public IEnumerable<Asignatura> ObtenerRevisionesProfesor(int idProfesor, int paginaActual, int filas,
            int? idEstado, string codigoAsignatura = null, string codigAno = null, string codiigoTrimestre = null)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "profesorId",Value =idProfesor},
               new SqlParameter{ParameterName = "codigoAsignatura",Value =  string.IsNullOrEmpty(codigoAsignatura) ? (object) DBNull.Value:codigoAsignatura},
               new SqlParameter{ParameterName = "codigoTrimestre",Value =string.IsNullOrEmpty(codiigoTrimestre) ?  (object) DBNull.Value:codiigoTrimestre},
               new SqlParameter { ParameterName = "codigoAno",Value =  string.IsNullOrEmpty(codigAno) ? (object)  DBNull.Value:codigAno},
               new SqlParameter{ParameterName = "paginaActual",Value = paginaActual},
               new SqlParameter { ParameterName = "filasPorPagina",Value = filas},
                new SqlParameter { ParameterName = "idEstado",Value = idEstado ==null || idEstado==0? (object)  DBNull.Value:idEstado}
           
           };
            var asignaturas = _asignaturaDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerRevisionesProfesor @profesorId, " +
                                                                      "@paginaActual, @filasPorPagina, @codigoAsignatura,@codigoTrimestre," +
                                                                      "@codigoAno, @idEstado", parametros.ToArray());
            return asignaturas;
        }
        public IEnumerable<Revision> ObtenerReporteRevisionesProfesor(int idProfesor,
            string codigoArea = null, string codigAno = null, string codiigoTrimestre = null)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "profesorId",Value =idProfesor},
               new SqlParameter{ParameterName = "area",Value =  string.IsNullOrEmpty(codigoArea) ? (object) DBNull.Value:codigoArea},
               new SqlParameter{ParameterName = "trimestre",Value =string.IsNullOrEmpty(codiigoTrimestre) ?  (object) DBNull.Value:codiigoTrimestre},
               new SqlParameter { ParameterName = "ano",Value =  string.IsNullOrEmpty(codigAno) ? (object)  DBNull.Value:codigAno}
             
           
           };
            var revisiones = _revisionDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerReporteRevisionesProfesor @profesorId, " +
                                                                      "@trimestre, @ano, @area", parametros.ToArray());
            return revisiones;
        }
        public IEnumerable<Revision> ObtenerReporteRevisionesArea(string codigoArea ,int? idProfesor, string codigAno = null,
            string codiigoTrimestre = null)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "profesorId",Value =idProfesor==0? (object) DBNull.Value:idProfesor},
               new SqlParameter{ParameterName = "area",Value =  codigoArea},
               new SqlParameter{ParameterName = "trimestre",Value =string.IsNullOrEmpty(codiigoTrimestre) ?  (object) DBNull.Value:codiigoTrimestre},
               new SqlParameter { ParameterName = "ano",Value =  string.IsNullOrEmpty(codigAno) ? (object)  DBNull.Value:codigAno}
             
           
           };
            var revisiones = _revisionDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerReporteRevisionesArea @area, " +
                                                                      "@profesorId, @trimestre, @ano", parametros.ToArray());
            return revisiones;
        }
        public IEnumerable<Asignatura> ObtenerRevisionesArea(string codigoArea, int? idProfesor, int paginaActual, int filas,
          int? idEstado, string codigoAsignatura = null, string codigAno = null, string codiigoTrimestre = null)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "profesorId",Value =idProfesor ==null || idProfesor==0? (object)  DBNull.Value:idProfesor},
               new SqlParameter{ParameterName = "codigoAsignatura",Value =  string.IsNullOrEmpty(codigoAsignatura) ? (object) DBNull.Value:codigoAsignatura},
               new SqlParameter{ParameterName = "codigoTrimestre",Value =string.IsNullOrEmpty(codiigoTrimestre) ?  (object) DBNull.Value:codiigoTrimestre},
               new SqlParameter { ParameterName = "codigoAno",Value =  string.IsNullOrEmpty(codigAno) ? (object)  DBNull.Value:codigAno},
               new SqlParameter{ParameterName = "paginaActual",Value = paginaActual},
               new SqlParameter { ParameterName = "filasPorPagina",Value = filas},
                new SqlParameter { ParameterName = "idEstado",Value = idEstado ==null || idEstado==0? (object)  DBNull.Value:idEstado},
                new SqlParameter { ParameterName = "codigoArea",Value = codigoArea},
           
           };
            var asignaturas = _asignaturaDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerRevisionesArea @profesorId, " +
                                                                      "@paginaActual, @filasPorPagina, @codigoAsignatura,@codigoTrimestre," +
                                                                      "@codigoAno, @idEstado, @codigoArea", parametros.ToArray());
            return asignaturas;
        }

        public ElementoFiltro GetTotalRevisionesCategoria(int idCategoria, int? idProfesor,
            string codigoAsignatura = null, string codigAno = null, string codiigoTrimestre = null, string codigoArea = null)
        {
            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "profesorId",Value =idProfesor==null|| idProfesor==0? (object)  DBNull.Value:idProfesor},
               new SqlParameter{ParameterName = "codigoAsignatura",Value =  string.IsNullOrEmpty(codigoAsignatura) ? (object) DBNull.Value:codigoAsignatura},
               new SqlParameter{ParameterName = "codigoTrimestre",Value =string.IsNullOrEmpty(codiigoTrimestre) ?  (object) DBNull.Value:codiigoTrimestre},
               new SqlParameter { ParameterName = "codigoAno",Value =  string.IsNullOrEmpty(codigAno) ? (object)  DBNull.Value:codigAno},
               new SqlParameter{ParameterName = "idCategoria",Value = idCategoria},
                 new SqlParameter{ParameterName = "codigoArea",Value = string.IsNullOrEmpty(codigoArea) ? (object)  DBNull.Value:codigoArea}
             
           
           };
            return _elementoFiltrDataAccess.ExecSqlCollectionSingle("exec INTEC_SP_GetTotalRevisionesxCategoria @idCategoria, @profesorId, " +
                                                                      "@codigoAsignatura,@codigoTrimestre, " +
                                                                      "@codigoAno,@codigoArea", parametros.ToArray());
        }

        public EstadoRevision ObtenerEstadoRevision(int idEstado)
        {
            var idParam = new SqlParameter
           {
               ParameterName = "IdEstadoRevision",
               Value = idEstado
           };
            _estadoRevisionDataAccess = new BaseRepository<EstadoRevision>();
            var estado = _estadoRevisionDataAccess.ExecSqlCollectionSingle("exec INTEC_SP_ObtenerEstadoRevision @IdEstadoRevision", idParam);
            return estado;

        }
        public Ciclo ObtenerCicloActual()
        {

            _cicloDataAccess = new BaseRepository<Ciclo>();
            var ciclo = _cicloDataAccess.ExecSqlCollectionSingle("exec INTEC_SP_GetTrimestreActual");
            return ciclo;

        }
        public IEnumerable<EstadoRevision> ObtenerEstadosRevision()
        {

            _estadoRevisionDataAccess = new BaseRepository<EstadoRevision>();
            var estados = _estadoRevisionDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerEstadosRevision");
            return estados;

        }
        public IEnumerable<ElementoFiltro> ObtenerAreas(int idProfesor)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "idProfesor",Value =idProfesor}
             
           
           };

            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var areas = _elementoFiltrDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerAreas @idProfesor", parametros.ToArray());
            return areas;

        }

        public IEnumerable<ElementoFiltro> ObtenerTrimestres()
        {

            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var trimestre = _elementoFiltrDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerTrimestres");
            return trimestre;

        }
        public IEnumerable<ElementoFiltro> ObtenerAnos()
        {

            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var trimestre = _elementoFiltrDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerAnos");
            return trimestre;

        }
        public IEnumerable<ElementoFiltro> ObtenerAsigaturasProfesor(int idProfesor)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "idProfesor",Value =idProfesor}
             
           
           };
            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var asignaturas = _elementoFiltrDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerAsignaturasprofesor @idProfesor", parametros.ToArray());
            return asignaturas;
        }
        public Revision ObtenerDatosSolicitud(int idRevision)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "revisionId",Value =idRevision}
             
           
           };

            var revision = _revisionDataAccess.ExecSqlCollectionSingle("exec INTEC_SP_ObtenerDatosSolicitud @revisionId", parametros.ToArray());
            return revision;
        }
        public Revision ObtenerDatosRevision(int idRevision)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "revisionId",Value =idRevision}
             
           
           };
         
            var revision = _revisionDataAccess.ExecSqlCollectionSingle("exec INTEC_SP_ObtenerDataRevision @revisionId", parametros.ToArray());
            return revision;
        }
        public IEnumerable<ElementoFiltro> ObtenerAsigaturasArea(string codigoArea)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "codigoArea",Value =codigoArea}
             
           
           };
            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var asignaturas = _elementoFiltrDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerAsignaturasArea @codigoArea", parametros.ToArray());
            return asignaturas;
        }
        public IEnumerable<ElementoFiltro> ObtenerProfesoresArea(string codigoArea)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "codigoArea",Value =codigoArea}
             
           
           };
            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var asignaturas = _elementoFiltrDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerProfesoresArea @codigoArea", parametros.ToArray());
            return asignaturas;
        }
        public IEnumerable<ElementoFiltro> ObtenerRepresentantesArea(string codigoArea)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "codigoArea",Value =codigoArea}
             
           
           };
            _elementoFiltrDataAccess = new BaseRepository<ElementoFiltro>();
            var asignaturas = _elementoFiltrDataAccess.ExecSqlCollection("exec INTEC_SP_ObtenerRepresentantesArea @codigoArea", parametros.ToArray());
            return asignaturas;
        }
        public Persona GetDatosPersona(int id)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "idPersona",Value =id}
             
           
           };
            _personaDataAccess=new BaseRepository<Persona>();
            var persona = _personaDataAccess.ExecSqlCollectionSingle("exec INTEC_SP_ObtenerDatosPersona @idPersona", parametros.ToArray());
            return persona;
        }

        public int ActualizarRevision(Revision revision)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "revisionId",Value = revision.RevisionId},
               new SqlParameter{ParameterName = "docenteId",Value = revision.DocenteId ?? (object) DBNull.Value},
               new SqlParameter{ParameterName = "representanteId",Value = revision.RepresentanteId ?? (object)  DBNull.Value},
               new SqlParameter { ParameterName = "lugar",Value =  string.IsNullOrEmpty(revision.LugarDisponible)
                   ?(object) DBNull.Value:revision.LugarDisponible},
               new SqlParameter{ParameterName = "fechaCita",Value = revision.FechaCita ?? (object) DBNull.Value},
               new SqlParameter { ParameterName = "comentarios",Value =  string.IsNullOrEmpty(revision.ComentarioAcedemcio)
                   ?(object) DBNull.Value:revision.ComentarioAcedemcio},
               new SqlParameter { ParameterName = "idEstado",Value = revision.IdEstado},
                new SqlParameter { ParameterName = "profesorAsistio",Value =  revision.ProfesorAsistio??
                   (object) DBNull.Value},
               new SqlParameter { ParameterName = "estudianteAsistio",Value =  revision.EstudianteAsistio??
                   (object) DBNull.Value},
                      new SqlParameter { ParameterName = "representanteAsistio",Value =  revision.RepresentanteAsistio??
                   (object) DBNull.Value},
                    new SqlParameter { ParameterName = "codigoNota",Value =  string.IsNullOrEmpty(revision.CodigoNota)
                   ?(object) DBNull.Value:revision.CodigoNota},
                       new SqlParameter { ParameterName = "valorNota",Value = revision.NotaAsignada??
                   (object) DBNull.Value},
                     new SqlParameter{ ParameterName = "fechaEstado",Value = revision.FechaClave}
       
           };
          return  _revisionDataAccess.ExcecuteProcedure(
              "exec INTEC_SP_ActualizarRevision @revisionId ,@docenteId, @representanteId ,@lugar " +
              ",@fechaCita, @comentarios,@idEstado,@profesorAsistio,@estudianteAsistio,@representanteAsistio, "+
            "@codigoNota,@valorNota,@fechaEstado",
              parametros.ToArray());
        }

        public  string ObtenerAreaUsuario(int idUsuario)
        {
            var parametros = new List<SqlParameter>
           {
               new SqlParameter{ ParameterName = "idUsuario",Value = idUsuario}
             
       
           };
            var area = _revisionDataAccess.ExecSqlCollectionSingle(
                "exec INTEC_SP_ObtenerAreaUsuario @idUsuario",
                parametros.ToArray()).Area;
            return area;

        }
        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool b)
        {
            if (!_disposing)
            {
                GC.SuppressFinalize(this);
                _disposing = true;
            }
        }

    }
}
