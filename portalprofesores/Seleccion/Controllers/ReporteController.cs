using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using Seleccion.Helpers;
using System.IO;
using DataAccess.Model;
using DataAccess;

namespace Seleccion.Controllers
{
    public class ReporteController : Controller
    {
        public ActionResult Index()
        {
            if (SimpleSecurity.HasStudent())
            {
                cargarPagina();
                return View();
            }

            return RedirectToAction("Login", "Main");
            
        }

        public ActionResult ObtenerPDF(string reporte, string ano, string termino)
        {
            // First read in the report into memory.
            //ConfigurationManager.AppSettings["rptServer"].ToString()

            string strReportUser = ConfigurationManager.AppSettings["rptUser"].ToString();
            string strReportUserPW = ConfigurationManager.AppSettings["rptPassword"].ToString();
            string strReportUserDomain = ConfigurationManager.AppSettings["rptDomain"].ToString();
            string sTargetURL = "";
            if (ano != "" && termino != "")
            {
                sTargetURL = ConfigurationManager.AppSettings["rptServer"].ToString() + "?" +
                   "/JNZ/RE/" + reporte + "&rs:Command=Render&rs:Format=PDF" +
                   "&ID_NUM=" + new SessionWrapper().Id +
                   "&Term=" + termino +
                   "&Year=" + ano;
            }
            else
            {
                sTargetURL = ConfigurationManager.AppSettings["rptServer"].ToString() + "?" +
                   "/JNZ/RE/" + reporte + "&rs:Command=Render&rs:Format=PDF" +
                   "&ID_NUM=" + new SessionWrapper().Id;
            }

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sTargetURL);
            req.PreAuthenticate = true;
            req.Credentials = new System.Net.NetworkCredential(
                strReportUser,
                strReportUserPW,
                strReportUserDomain);

            HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();

            Stream fStream = HttpWResp.GetResponseStream();

            //Now turn around and send this as the response..
            byte[] fileBytes = ReadFully(fStream);
            // Could save to a database or file here as well.
            Estudiante estudiante = new EstudianteRepository().SearchById(new SessionWrapper().Id, TipoEstudiante.EstudianteRetiro);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader(
                "content-disposition",
                "attachment; filename=\"" +
                    estudiante.ID + " - " +
                    reporte +
                    ".pdf\"");

            Response.BinaryWrite(fileBytes);
            Response.Flush();
            Response.End();

            HttpWResp.Close();
            cargarPagina();
            return View("Index");
        }

        private static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private void cargarPagina()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Value = "1", Text = "Febrero - Abril" });
            items.Add(new SelectListItem() { Value = "2", Text = "Mayo - Julio" });
            items.Add(new SelectListItem() { Value = "3", Text = "Agosto - Octubre" });
            items.Add(new SelectListItem() { Value = "4", Text = "Noviembre - Enero" });

            ViewBag.User = new SessionWrapper().Id;
            ViewBag.periodos = items;
        }
    }
}
