using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class RevisionAreaController:Controller
    {
        private readonly RevisionNotaHelper _revisionServ;
        public const int FilasPagina = 3;
        public const int IdUsuario = 401343;//ProfesorHelper.ObtenerProfesor().ID  ;
        public  string CodigoArea;

        public RevisionAreaController()
        {
                     
            _revisionServ = new RevisionNotaHelper();
            if(CodigoArea==null)
            CodigoArea = _revisionServ.ObtenerAreaUsuario(IdUsuario);
        }

        public ActionResult Index()
        {
            var revisiones = new PageData<Asignatura>();
            int totalFilas;
            var ciclo = _revisionServ.ObtenerCicloActual();
            ViewBag.Anos = _revisionServ.ObtenerAnos(ciclo.Ano);
            ViewBag.Trimestres = _revisionServ.ObtenerTrimestres(ciclo.periodo);
            ViewBag.Asignaturas = _revisionServ.ObtenerAsigaturasArea(CodigoArea);
            ViewBag.Estados = _revisionServ.ObtenerEstadosRevision();
            ViewBag.Profesores = _revisionServ.ObtenerProfesoresArea(CodigoArea);
            revisiones.Data = _revisionServ.ObtenerRevisionesArea(CodigoArea,null, 1, FilasPagina, out totalFilas, null, codigAno:
               ciclo.Ano, codiigoTrimestre: ciclo.periodo);
            revisiones.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)totalFilas / FilasPagina));
            revisiones.CurrentPage = 1;
            revisiones.TotalRows = totalFilas;


            return View(revisiones);
        }
        public ActionResult ReporteRevisiones()
        {
            ViewBag.Trimestres = _revisionServ.ObtenerTrimestres();
            ViewBag.Anos = _revisionServ.ObtenerAnos(null);
            ViewBag.Profesores = _revisionServ.ObtenerProfesoresArea(CodigoArea);
            ViewBag.CodigoArea = CodigoArea;
            return View();
        }

        public JsonResult GetDatosEstudiante(int id)
        {
            return Json(_revisionServ.GetDatosPersona(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerTrimestres()
        {
            return Json(_revisionServ.ObtenerTrimestres(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerDocentes()
        {
            return Json(_revisionServ.ObtenerProfesoresArea(CodigoArea), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerRepresentantes()
        {
            return Json(_revisionServ.ObtenerRepresentantesArea(CodigoArea), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerAnos()
        {
            return Json(_revisionServ.ObtenerAnos(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerAsignaturasArea()
        {
            return Json(_revisionServ.ObtenerAsigaturasArea(CodigoArea), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerEstados()
        {
            return Json(_revisionServ.ObtenerEstadosRevision(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerTotalesCategoria(string ano, string trimestre, string asignatura)
        {

            return Json(new
            {
                normal = _revisionServ.GetTotalRevisionesCategoria(1, null, asignatura, ano, trimestre,CodigoArea).TotalRegistros,
                moderado = _revisionServ.GetTotalRevisionesCategoria(2, null, asignatura, ano, trimestre,CodigoArea).TotalRegistros,
                critico = _revisionServ.GetTotalRevisionesCategoria(3, null, asignatura, ano, trimestre,CodigoArea).TotalRegistros
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerCodigoNota(double nota,string notaActual)
        {
            var codigoNota = _revisionServ.ObtenerCodigoNota(nota, notaActual);
            if (codigoNota == string.Empty)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Json(new { status = Response });
            }
            return Json(new
            {
                codigoNota = codigoNota
               
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAsignaturasRevision(int pagina, int? idEstado,int? idProfesor, string ano=null, string trimestre=null, string asignatura=null)
        {
            var revisiones = new PageData<Asignatura>();
            int totalFilas;
          
            revisiones.Data = _revisionServ.ObtenerRevisionesArea(CodigoArea, idProfesor, pagina, FilasPagina, out totalFilas, idEstado, codigAno:
               ano, codiigoTrimestre: trimestre,codigoAsignatura:asignatura);
            revisiones.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)totalFilas / FilasPagina));
            revisiones.CurrentPage = 1;
            revisiones.TotalRows = totalFilas;


            return PartialView("_AsignaturasRevision", revisiones);
        }

        public FileResult ObtenerFormularioSolicitud(int idRevision,int idEstado)
        {
            var rutaReporte = Path.Combine(Server.MapPath("~/Reportes/Formulario_Solicitud_Revisión__Calificaciones.pdf"));

            if(idEstado>2)
            {
                var contenido = _revisionServ.GeneratePDFSolicitud(idRevision, rutaReporte);
                return File(contenido, "application/pdf");
            }
            else
            {
                var fs = new FileStream(rutaReporte, FileMode.Open, FileAccess.Read);
                return File(fs, "application/pdf");

            }

          
        }
        public FileResult ObtenerReporteCambioCalificacion(int idRevision, int idEstado)
        {
            var rutaReporte = Path.Combine(Server.MapPath("~/Reportes/Reporte_Registro_Cambio_Calificaciones.pdf"));
            if (idEstado > 3)
            {
                var contenido = _revisionServ.GeneratePDFRegistroCambio(idRevision, rutaReporte);
                return File(contenido, "application/pdf");
            }
            else
            {
                var fs = new FileStream(rutaReporte, FileMode.Open, FileAccess.Read);
                return File(fs, "application/pdf");

            }
        }


        [HttpPost]
        public JsonResult ActualizarRevision(int revisionId, int? docenteAsignado, int? representanteId,
            string lugar, string comentarios, DateTime? fechaCita,bool profesorAsistio,bool estudianteAsistio,
            bool? representanteAsistio,string codigoNota, double? valorNota,int idEstadoActual, int? codigoCambio,
            int tabSeleccionado)
        {
            var estado = idEstadoActual;
          
            if (idEstadoActual < 3)
            
                estado = 3;
             
            
            else
            {
                if (codigoCambio != null && codigoCambio >0)
                    estado = (int) codigoCambio;
                else if (tabSeleccionado==2 && !estudianteAsistio)
                    estado = 5;
              
            }

            var revision = new Revision
            {
                RevisionId = revisionId,
                RepresentanteId = representanteId,
                DocenteId = docenteAsignado,
                LugarDisponible = lugar,
                ComentarioAcedemcio = comentarios,
                FechaCita = fechaCita,
                IdEstado = estado,
                ProfesorAsistio = profesorAsistio,
                EstudianteAsistio = estudianteAsistio,
                RepresentanteAsistio = representanteAsistio,
                CodigoNota = codigoNota,
                NotaAsignada = valorNota,
                FechaClave = DateTime.Now
            };
            _revisionServ.ActualizarRevision(revision);
            var estadoRevision = _revisionServ.ObtenerEstadoRevision(revision.IdEstado);
                 return Json(new
            {
                fechaClave =revision.IdEstado==3? revision.FechaCita.ToString():revision.FechaClave.ToString(),
                estado = estadoRevision.Descripcion,
                mensajeEstado=estadoRevision.Mensaje,
                idEstado=estado
               
            });
        }
    }
}