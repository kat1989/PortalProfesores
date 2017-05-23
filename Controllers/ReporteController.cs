using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seleccion.Helpers;
using DataAccess;
using WebUI.Helpers;
using Logger;
using System.Configuration;
using System.Net;
using System.IO;
using WebUI.Classes;

namespace WebUI.Controllers
{
    public class ReporteController : Controller
    {
        public ActionResult Index()
        {
            if (SimpleSecurity.HaySessionActiva())
            {
                try
                {
                    var p = ProfesorHelper.ObtenerProfesor();
                    //ViewBag.Areas = new AreaRepository().RetrieveAll();

                    return View(p);
                }
                catch (Exception ex)
                {
                    EventLogger logger = new EventLogger("SiteProfesores");
                    string information = "";
                    information += "Ubicacion: Main/GenerarReporte \n";
                    information += "Id Profesor:" + WrapperSession.ObtenerInstancia().Id + "\n";
                    information += "Error: " + ex.Message + "\n";
                    information += "Inner Exception: " + ex.InnerException + "\n";
                    if (ex.InnerException != null)
                        information += "Inner Exception Messaje: " + ex.InnerException.Message + "\n";
                    information += "Stack Trace: " + ex.StackTrace + "\n";

                    logger.Error(information);
                }
                return RedirectToAction("Login", "Main");
            }
            else
            {
                TempData["Timeout"] = true;
                return RedirectToAction("Login", "Main");
            }
        }

        //public void Exportar(string indiceReporte, ParametrosReporte parametros)
        //{
        //    try
        //    {
        //        if (String.IsNullOrEmpty(parametros.Termino) && String.IsNullOrEmpty(parametros.Ano))
        //        {
        //            var periodoActual = new PeriodoRepository().RetrieveAll().FirstOrDefault();
        //            parametros.Termino = periodoActual.Termino;
        //            parametros.Ano = periodoActual.Ano;
        //        }
        //        var result = CargarInformacion(indiceReporte, parametros);
        //        GenerarReporte(result.url, result.titulo, result.parametros);
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLogger logger = new EventLogger("SiteProfesores");
        //        string information = "";
        //        information += "Ubicacion: Main/GenerarReporte \n";
        //        information += "Id Profesor:" + WrapperSession.ObtenerInstancia().Id + "\n";
        //        information += "Error: " + ex.Message + "\n";
        //        information += "Inner Exception: " + ex.InnerException + "\n";
        //        if (ex.InnerException != null)
        //            information += "Inner Exception Messaje: " + ex.InnerException.Message + "\n";
        //        information += "Stack Trace: " + ex.StackTrace + "\n";

        //        logger.Error(information);
        //    }
        //}

        //[HttpPost]
        //public ActionResult ObtenerCarreras(int idEstudiante)
        //{
        //    var carreras = new CarrerasRepository().ObtenerCarreras(idEstudiante);
        //    return Json(new { carreras = carreras.Select(m => new { m.Codigo, m.Descripcion }) });
        //}

        //#region Metodos Privados
        //private dynamic CargarInformacion(string indiceReporte, ParametrosReporte parametros)
        //{
        //    var dataReporte = ReportCenterConfiguration.Instance.Reports[indiceReporte];
        //    var args = new Dictionary<string, string>();
        //    var periodoActual = new PeriodoRepository().RetrieveAll().FirstOrDefault();

        //    parametros.ID = String.IsNullOrEmpty(parametros.ID) ? WrapperSession.ObtenerInstancia().Id : parametros.ID;
        //    parametros.Ano = String.IsNullOrEmpty(parametros.Ano) ? periodoActual.Ano : parametros.Ano;
        //    parametros.Termino = String.IsNullOrEmpty(parametros.Termino) ? periodoActual.Termino : parametros.Termino;

        //    switch (indiceReporte)
        //    {
        //        case "1":
        //            {
        //                args.Add("PROFESOR", parametros.ID);
        //                args.Add("ANO", parametros.Ano);
        //                args.Add("TERMINO", parametros.Termino);
        //                args.Add("ASIGNATURA", parametros.Asignatura);
        //                break;
        //            }
        //        case "2":
        //            {
        //                args.Add("PROFESOR", parametros.ID);
        //                args.Add("ANO", parametros.Ano);
        //                args.Add("TERMINO", parametros.Termino);
        //                args.Add("ASIGNATURA", parametros.Asignatura);
        //                break;
        //            }
        //        case "3":
        //            {
        //                args.Add("PROFESOR", parametros.ID);
        //                args.Add("ANO", parametros.Ano);
        //                args.Add("TERMINO", parametros.Termino);
        //                args.Add("ASIGNATURA", parametros.Asignatura); 
        //                break;
        //            }
        //        case "4":
        //            {
        //                args.Add("ID_NUM", parametros.ID);
        //                args.Add("PROGRAMA", parametros.Programa);
        //                break;
        //            }
        //        case "5":
        //            {
        //                args.Add("ID", parametros.ID);
        //                args.Add("PROGRAMA", parametros.Programa);
        //                break;
        //            }
        //        case "6":
        //            {
        //                args.Add("AREA", parametros.Area);
        //                args.Add("TERMINO", parametros.Termino);
        //                args.Add("AÑO", parametros.Ano);
        //                break;
        //            }
        //        case "7":
        //            {
        //                args.Add("AREA", parametros.Area);
        //                args.Add("TERMINO", parametros.Termino);
        //                args.Add("AÑO", parametros.Ano);
        //                break;
        //            }
        //        case "8":
        //            {
        //                args.Add("ID_NUM", parametros.ID);
        //                args.Add("Term", parametros.Termino);
        //                args.Add("Year", parametros.Ano);
        //                break;
        //            }
        //        case "9":
        //            {
        //                args.Add("ID_NUM", parametros.ID);
        //                args.Add("Term", parametros.Termino);
        //                args.Add("Year", parametros.Ano);
        //                break;
        //            }
        //        default: break;
        //    }

        //    return new { url = dataReporte.Direccion, parametros = args, titulo = dataReporte.Visualization };
        //}

        //private void GenerarReporte(string url, string fileName, Dictionary<string, string> param)
        //{
        //    string id = WrapperSession.ObtenerInstancia().Id;
        //    byte[] fileBytes = new MemoryLoader().LoadReport(url, FileFormat.Pdf, param);

        //    Response.Clear();
        //    Response.ContentType = "application/pdf";

        //    var header = "attachment; filename=\"" + fileName + "." + FileFormat.Pdf.ToString();

        //    Response.AddHeader("content-disposition", header);

        //    Response.BinaryWrite(fileBytes);
        //    Response.Flush();
        //    Response.End();
        //}
        //#endregion
    }
}
