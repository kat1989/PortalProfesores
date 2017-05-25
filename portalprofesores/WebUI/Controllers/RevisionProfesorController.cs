﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class RevisionProfesorController:Controller
    {
        private readonly RevisionNotaHelper _revisionServ;
        public const int FilasPagina = 3;
        public const int IdProfesor = 1041564;

        public RevisionProfesorController()
        {
           
           

            _revisionServ=new RevisionNotaHelper();
        }

        public ActionResult Index()
        {
            ViewBag.Trimestres = _revisionServ.ObtenerTrimestres();
         
            var revisiones = new PageData<Asignatura>();
            int totalFilas;
            var ciclo = _revisionServ.ObtenerCicloActual();
            ViewBag.Anos = _revisionServ.ObtenerAnos(ciclo.Ano);
            ViewBag.Trimestres = _revisionServ.ObtenerTrimestres(ciclo.periodo);
            ViewBag.Asignaturas = _revisionServ.ObtenerAsigaturasProfesor(IdProfesor);
            ViewBag.Estados = _revisionServ.ObtenerEstadosRevision();
            revisiones.Data = _revisionServ.ObtenerRevisionesProfesor(IdProfesor, 1, FilasPagina, out totalFilas,null,codigAno:
               ciclo.Ano,codiigoTrimestre:ciclo.periodo);
            revisiones.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)totalFilas / FilasPagina));
            revisiones.CurrentPage = 1;
            revisiones.TotalRows = totalFilas;


            return View(revisiones);
        }
        public  ActionResult ReporteRevisiones()
        {
            ViewBag.Trimestres = _revisionServ.ObtenerTrimestres();
            ViewBag.Anos = _revisionServ.ObtenerAnos(null);
            ViewBag.Areas = _revisionServ.ObtenerAreas(IdProfesor);
            ViewBag.IdProfesor = IdProfesor;
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
        public JsonResult ObtenerAnos()
        {
            return Json(_revisionServ.ObtenerAnos(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerAsignaturasProfesor()
        {
            return Json(_revisionServ.ObtenerAsigaturasProfesor(IdProfesor), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerEstados()
        {
            return Json(_revisionServ.ObtenerEstadosRevision(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerTotalesCategoria(string ano, string trimestre, string asignatura)
        {

            return Json(new{
                normal=_revisionServ.GetTotalRevisionesCategoria(1, IdProfesor, asignatura, ano, trimestre).TotalRegistros,
                moderado = _revisionServ.GetTotalRevisionesCategoria(2, IdProfesor, asignatura, ano, trimestre).TotalRegistros,
                critico = _revisionServ.GetTotalRevisionesCategoria(3, IdProfesor, asignatura, ano, trimestre).TotalRegistros
        } ,JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAsignaturasRevision(int pagina, int? idEstado, string ano = null, string trimestre = null, string asignatura = null)
        {
            var revisiones = new PageData<Asignatura>();
            int totalFilas;

            revisiones.Data = _revisionServ.ObtenerRevisionesProfesor(IdProfesor, pagina, FilasPagina, out totalFilas,codigAno:ano,
                codigoAsignatura:asignatura,codiigoTrimestre:trimestre,idEstado:idEstado);
            revisiones.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)totalFilas / FilasPagina));
            revisiones.CurrentPage = pagina;
            revisiones.TotalRows = totalFilas;


            return PartialView("_AsignaturasRevision",revisiones);
        }

    }
}