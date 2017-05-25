using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Model;
using DataAccess.Adapter;
using Seleccion.Helpers;
using System.Net;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;

namespace Seleccion.Controllers
{
    public class RetiroController : Controller
    {
        //
        // GET: /Retiro/

        public ActionResult Index()
        {
            Response.AppendHeader("Cache-Control", "no-store");

            SessionWrapper session = new SessionWrapper();
            ViewBag.ID = session.Id;
            if (SimpleSecurity.HasStudent() && SimpleSecurity.ValidarEntrada("R") == "")
            {
                EstudianteRetiro estudiante = (EstudianteRetiro) new EstudianteRepository().SearchById(session.Id,TipoEstudiante.EstudianteRetiro);

                return View(estudiante);
            }
            return RedirectToAction("Login", "Main");
        }

        [HttpPost]
        public ActionResult Index(EstudianteRetiro estudiante, string username, string password)
        {
            if (SimpleSecurity.HasStudent())
            {
                JenzabarEntities entities = new JenzabarEntities();
                EstudianteRetiro data = (EstudianteRetiro) new EstudianteRepository().SearchById(new SessionWrapper().Id,TipoEstudiante.EstudianteRetiro);
                int id = SimpleSecurity.Login("",username,password);

                if (id > 1)
                {
                    foreach (var item in estudiante.Asignaturas)
                    {
                        if (item.New == true)
                        {
                            var dataItem = data.Asignaturas.
                                Where(m => m.Codigo == item.Codigo)
                                .FirstOrDefault();

                            entities.RetirarAsignatura(id.ToString(), item.Codigo,
                                System.Environment.MachineName,Request.UserHostAddress);

                            dataItem.Estatus = 1;
                            dataItem.New = true;
                            data.TotalAsignaturasEnCurso--;
                            data.TotalAsignaturasRetiradas++;
                        }
                    }
                    EnviarPDF("Reporte Retiros Estudiantes");
                    return View("Resumen", data);
                }
            }
            return RedirectToAction("Login", "Main");
        }

        public ActionResult Resumen()
        {
            EstudianteRetiro estudiante = (EstudianteRetiro) new EstudianteRepository().SearchById(new SessionWrapper().Id,TipoEstudiante.EstudianteRetiro);
            estudiante.Asignaturas = estudiante.Asignaturas.Where(m => m.FechaRetiro == DateTime.Now).ToList();

            return View(estudiante);
        }

        public ActionResult ObtenerPDF()
        {
            // First read in the report into memory.
            //ConfigurationManager.AppSettings["rptServer"].ToString()

            string strReportUser = ConfigurationManager.AppSettings["rptUser"].ToString();
            string strReportUserPW = ConfigurationManager.AppSettings["rptPassword"].ToString();
            string strReportUserDomain = ConfigurationManager.AppSettings["rptDomain"].ToString();
            string sTargetURL = ConfigurationManager.AppSettings["rptServer"].ToString() + "?"+
               "/JNZ/RE/Reporte Retiros Estudiantes&rs:Command=Render&rs:Format=PDF&id="+ new SessionWrapper().Id;

            HttpWebRequest req =
                  (HttpWebRequest)WebRequest.Create(sTargetURL);
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
            Estudiante estudiante = new EstudianteRepository().SearchById(new SessionWrapper().Id,TipoEstudiante.EstudianteRetiro);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader(
                "content-disposition",
                "attachment; filename=\"" +
                    estudiante.Nombre +" "+
                    estudiante.SegundoNombre + " "+ 
                    estudiante.Apellido +" - "+
                    estudiante.Matricula +
                    ".pdf\"");

            Response.BinaryWrite(fileBytes);
            Response.Flush();
            Response.End();

            HttpWResp.Close();
            return View();
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public void EnviarPDF(string reporte)
        {

            EstudianteRetiro estudiante = (EstudianteRetiro)new EstudianteRepository().
                SearchById(new SessionWrapper().Id, TipoEstudiante.EstudianteRetiro);


            string strReportUser = ConfigurationManager.AppSettings["rptUser"].ToString();
            string strReportUserPW = ConfigurationManager.AppSettings["rptPassword"].ToString();
            string strReportUserDomain = ConfigurationManager.AppSettings["rptDomain"].ToString();
            string sTargetURL = ConfigurationManager.AppSettings["rptServer"].ToString() + "?" +
               "/JNZ/RE/Reporte Retiros Estudiantes&rs:Command=Render&rs:Format=PDF&id=" + estudiante.ID;

            HttpWebRequest req =
                  (HttpWebRequest)WebRequest.Create(sTargetURL);
            req.PreAuthenticate = true;
            req.Credentials = new System.Net.NetworkCredential(
                strReportUser,
                strReportUserPW,
                strReportUserDomain);

            HttpWebResponse HttpWResp = (HttpWebResponse)req.GetResponse();

            Stream fStream = HttpWResp.GetResponseStream();

            SmtpClient SMTPServer = new SmtpClient("192.168.0.22");
            MailMessage mailObj = new MailMessage("sistema.vriv@intec.edu.do", "raul.montero@intec.edu.do", "Reporte de seleccion", "Prueba");
            mailObj.Attachments.Add(new Attachment(fStream, new ContentType("application/pdf")));
            mailObj.IsBodyHtml = true;
            SMTPServer.Send(mailObj);

            HttpWResp.Close();
        }
    }
}
