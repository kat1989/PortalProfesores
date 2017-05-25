using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Model;

namespace WebUI.Helpers
{
    public class RevisionNotaHelper : IDisposable
    {
        private bool _disposing;

        private readonly RevisionRepository _revisionRepository;
      
      
     
        public RevisionNotaHelper()
        {
            _revisionRepository=new RevisionRepository();
           

        }

       

        public IEnumerable<Asignatura> ObtenerRevisionesProfesor(int idProfesor, int paginaActual, int filas,out int totalAsignaturas,
            int? idEstado,string codigoAsignatura = null, string codigAno = null, string codiigoTrimestre = null)
        {
            var asignaturas=_revisionRepository.ObtenerRevisionesProfesor(idProfesor, paginaActual, filas,idEstado,
                codigoAsignatura, codigAno, codiigoTrimestre).ToList();
           
            totalAsignaturas =asignaturas.Any()? asignaturas.FirstOrDefault().TotalAsignaturas:0;
            asignaturas.ForEach(a =>
            {
                a.EstadoRevision = ObtenerEstadoRevision(a.IdEstadoRevision);
                a.FechaClave = a.IdEstadoRevision == 2
                    ? Convert.ToDateTime(a.FechaRevisionSolicitada)
                    : (a.IdEstadoRevision==3?Convert.ToDateTime(a.FechaAgendada):Convert.ToDateTime(a.FechaEstatus));
                var cantidadDiasSolicitud = DateTime.Now.Subtract(a.FechaClave).Days;
                a.EstadoSolicitud = cantidadDiasSolicitud <= 2
                    ? EstadosSolictudRevision.Normal
                    : (cantidadDiasSolicitud>2 && cantidadDiasSolicitud<=4? EstadosSolictudRevision.Moderado : EstadosSolictudRevision.Critico);
            });
            return asignaturas;
        }

        public IEnumerable<Asignatura> ObtenerRevisionesArea( string codigoArea,int? idProfesor, int paginaActual, int filas, out int totalAsignaturas,
           int? idEstado, string codigoAsignatura = null, string codigAno = null, string codiigoTrimestre = null)
        {
            
            var asignaturas = _revisionRepository.ObtenerRevisionesArea(codigoArea, idProfesor, paginaActual, filas, idEstado,
                codigoAsignatura, codigAno, codiigoTrimestre).ToList();

            totalAsignaturas = asignaturas.Any() ? asignaturas.FirstOrDefault().TotalAsignaturas : 0;
            asignaturas.ForEach(a =>
            {
                a.Revision = ObtenerDatosRevision((int) a.IdRevison);
                a.EstadoRevision = ObtenerEstadoRevision(a.IdEstadoRevision);
                a.FechaClave = a.IdEstadoRevision == 2
                    ? Convert.ToDateTime(a.FechaRevisionSolicitada)
                    :(a.IdEstadoRevision==3?Convert.ToDateTime(a.FechaAgendada): Convert.ToDateTime(a.FechaEstatus));
                var cantidadDiasSolicitud = DateTime.Now.Subtract(a.FechaClave).Days;
                a.EstadoSolicitud = cantidadDiasSolicitud <= 2
                    ? EstadosSolictudRevision.Normal
                    : (cantidadDiasSolicitud > 2 && cantidadDiasSolicitud <= 4 ? EstadosSolictudRevision.Moderado : EstadosSolictudRevision.Critico);
            });
            return asignaturas;
        }
        public EstadoRevision ObtenerEstadoRevision(int idEstado)
        {
            return _revisionRepository.ObtenerEstadoRevision(idEstado);
        }
        public IEnumerable<ElementoFiltro> ObtenerAreas(int idProfesor)
        {
            return _revisionRepository.ObtenerAreas(idProfesor);

        }

        public IEnumerable<EstadoRevision> ObtenerEstadosRevision()
        {
            return _revisionRepository.ObtenerEstadosRevision();
        }
        public Revision ObtenerDatosSolicitud(int idRevision)
        {
            return _revisionRepository.ObtenerDatosSolicitud(idRevision);
        }
        public Revision ObtenerDatosRevision(int idRevision)
        {
            return _revisionRepository.ObtenerDatosRevision(idRevision);
        }

        public IEnumerable<ElementoFiltro> ObtenerTrimestres(string trimestreActual=null)
        {
            var trimestres = _revisionRepository.ObtenerTrimestres().ToList();
            var trimestre = trimestreActual!=null? trimestreActual.Trim():trimestreActual;
            var firstOrDefault = trimestres.FirstOrDefault(a=>a.Codigo==trimestre);
            if (firstOrDefault == null) return trimestres;
            if (trimestreActual != null) firstOrDefault.ValorDefecto = trimestreActual.Trim();
            return trimestres;
        }

        public IEnumerable<ElementoFiltro> ObtenerAnos(string anoActual=null)
        {
            var anos = _revisionRepository.ObtenerAnos().ToList();
            var firstOrDefault = anos.FirstOrDefault(a=>a.Codigo==anoActual);
            if (firstOrDefault == null) return anos;
            if (anoActual != null) firstOrDefault.ValorDefecto = anoActual.Trim();
            return anos;
        }

        public IEnumerable<ElementoFiltro> ObtenerAsigaturasProfesor(int idProfesor)
        {
            return _revisionRepository.ObtenerAsigaturasProfesor(idProfesor);
        }

        public IEnumerable<ElementoFiltro> ObtenerProfesoresArea(string codigoArea)
        {
            return _revisionRepository.ObtenerProfesoresArea(codigoArea);
        }

        public IEnumerable<ElementoFiltro> ObtenerRepresentantesArea(string codigoArea)
        {
            return _revisionRepository.ObtenerRepresentantesArea(codigoArea);
        }

        public IEnumerable<ElementoFiltro> ObtenerAsigaturasArea(string codigoArea)
        {
            return _revisionRepository.ObtenerAsigaturasArea(codigoArea);
        }
        public IEnumerable<Revision> ObtenerReporteRevisionesProfesor(int idProfesor,
          string codigoArea = null, string codigAno = null, string codiigoTrimestre = null)
        {
            return _revisionRepository.ObtenerReporteRevisionesProfesor(idProfesor, codigoArea, codigAno, codiigoTrimestre);
        }
        public IEnumerable<Revision> ObtenerReporteRevisionesArea(string codigoArea, int? idProfesor, string codigAno = null,
         string codiigoTrimestre = null)
        {
            return _revisionRepository.ObtenerReporteRevisionesArea(codigoArea, idProfesor, codigAno, codiigoTrimestre);
        }
        public ElementoFiltro GetTotalRevisionesCategoria(int idCategoria, int? idProfesor,
            string codigoAsignatura = null, string codigAno = null, string codiigoTrimestre = null,
            string codigoArea=null)
        {
            return _revisionRepository.GetTotalRevisionesCategoria(idCategoria, idProfesor, codigoAsignatura,
                codigAno, codiigoTrimestre,codigoArea);
        }

        public Ciclo ObtenerCicloActual()
        {
            return _revisionRepository.ObtenerCicloActual();
        }

        public Persona GetDatosPersona(int id)
        {
            return _revisionRepository.GetDatosPersona(id);
        }
        public int ActualizarRevision(Revision revision)
        {
            return _revisionRepository.ActualizarRevision(revision);
        }

        private Dictionary<string, string> LLenarReporteSolicitud(int idRevision, string ruta)
        {
            var revision = ObtenerDatosSolicitud(idRevision);
          

            var camposFormulario = PDFHelper.GetFormFieldNames(ruta);
            camposFormulario["txtArea"] = revision.Area;
            camposFormulario["txtCarrera"] = revision.Carrera;
            camposFormulario["txtProfesor"] = revision.ProfesorNombre;
            camposFormulario["txtAsignatura"] = revision.NombreAsignatura;
            camposFormulario["txtClaveAsignatura"] = revision.CodigoAsignatura;
            camposFormulario["txtIdEstudiante"] = revision.EstudianteId.ToString();
            camposFormulario["txtNombreEstudiante"] = revision.EstudianteNombre;
            camposFormulario["txtCorreoEstudiante"] = revision.CorreoEstudiante;
            camposFormulario["txtTrimestre"] = revision.Trimestre+" "+revision.Ano;
            camposFormulario["txtFechaSolicitud"] = revision.FechaClave.ToString();
            camposFormulario["txtElementoRevision"] = revision.ElementoRevision;
            camposFormulario["txtMotivoRevision"] = revision.MotivoRevision;
            camposFormulario["txtPuntajeAsignado"] = revision.PuntajeAsignado.ToString();
            camposFormulario["txtPuntajeObtenido"] = revision.PuntajeObtenido.ToString();
            camposFormulario["txtGrado"] = revision.CodigoDivision.Equals("G",StringComparison.OrdinalIgnoreCase) ? 
                "X" : string.Empty; 
            camposFormulario["txtPostgrado"] = revision.CodigoDivision.Equals("P",StringComparison.OrdinalIgnoreCase)
                ? "X" : string.Empty;
            




            return camposFormulario;
        }
        private Dictionary<string, string> LLenarReporterRegistroCambio(int idRevision, string ruta)
        {
            var revision = ObtenerDatosSolicitud(idRevision);
            var calificaciones = new string[] { "A", "B", "B+", "C", "C+", "D", "F", "I" };

            var camposFormulario = PDFHelper.GetFormFieldNames(ruta);
            camposFormulario["txtArea"] = revision.Area;
            camposFormulario["txtCarrera"] = revision.Carrera;
            camposFormulario["txtProfesor"] = revision.ProfesorNombre;
            camposFormulario["txtAsignatura"] = revision.NombreAsignatura;
            camposFormulario["txtClaveAsignatura"] = revision.CodigoAsignatura;
            camposFormulario["txtIdEstudiante"] = revision.EstudianteId.ToString();
            camposFormulario["txtNombreEstudiante"] = revision.EstudianteNombre;
            camposFormulario["txtClaveAsignatura"] = revision.CodigoAsignatura;
            camposFormulario["txtTrimestre"] = revision.Trimestre + " " + revision.Ano;
            foreach(var calificacion in calificaciones)
            {
                
                camposFormulario["calificacionAnterior_" + calificacion] =revision.CodigoNotaAnterior.Trim().Equals(calificacion,
                    StringComparison.OrdinalIgnoreCase)?"[ "+calificacion+" ]":calificacion;
                camposFormulario["calificacionFinal_" + calificacion] = !string.IsNullOrEmpty(revision.CodigoNota) && 
                    revision.CodigoNota.Trim().Equals(calificacion,
                    StringComparison.OrdinalIgnoreCase) ? "[ " + calificacion + " ]" : calificacion;
            }
           





            return camposFormulario;
        }
       
        public  byte[] GeneratePDFSolicitud(int idRevision,string ruta)
        {
            var camposMapeados=LLenarReporteSolicitud(idRevision,ruta);
            var contenidoPdf = PDFHelper.GeneratePDF(ruta, camposMapeados);
            return contenidoPdf;
        }
        public byte[] GeneratePDFRegistroCambio(int idRevision, string ruta)
        {
            var camposMapeados = LLenarReporterRegistroCambio(idRevision, ruta);
            var contenidoPdf = PDFHelper.GeneratePDF(ruta, camposMapeados);
            return contenidoPdf;
        }

        public string ObtenerCodigoNota(double nota,string notaActual)
        {
            
            var codigoNota = "NA";
            if (nota >= 90 && nota <= 100)
                codigoNota = "A";
            else if (nota >= 85 && nota <= 89)
                codigoNota = "B+";
            else if (nota >= 80 && nota <= 84)
                codigoNota = "B";
            else if (nota >= 75 && nota <= 79)
                codigoNota = "C+";
            else if (nota >= 70 && nota <= 74)
                codigoNota = "C";
            else if (nota >= 60 && nota <= 69)
                codigoNota = "D";
            else if (nota >= 0 && nota <= 59)
                codigoNota = "F";
            if (codigoNota.CompareTo(notaActual)>=0)
                codigoNota = string.Empty;
                return codigoNota;


        }
        public  string ObtenerAreaUsuario(int idUsuario)
        {
            return _revisionRepository.ObtenerAreaUsuario(idUsuario);
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