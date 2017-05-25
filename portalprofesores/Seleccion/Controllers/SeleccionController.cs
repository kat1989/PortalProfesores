using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;
using DataAccess;
using Seleccion.Helpers;
using Seleccion.Classes;
using System.Configuration;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace Seleccion.Controllers
{
    public class SeleccionController : Controller
    {

        private SeleccionAbstractState state;

        public SeleccionController()
        {
            SessionWrapper session = new SessionWrapper();

            if (session.SeleccionState == 1)
            {
                state = new SeleccionState();
            }
            else if (session.SeleccionState == 2)
            {
                state = new PreseleccionState();
            }
        }

        public ActionResult Index(int tipo=0)
        {
            string param = "";
            if (tipo == 0) param = "P";
            if (tipo == 1) param = "S";
            

            if (SimpleSecurity.HasStudent() && SimpleSecurity.ValidarEntrada(param) == "")
            {
                SessionWrapper wrapper = new SessionWrapper();

                if (tipo == 0)
                {
                    ViewBag.Title = "Pre-Seleccion de Asignaturas";
                    wrapper.SeleccionState = 2; 
                    state = new PreseleccionState();
                }
                if (tipo == 1)
                {
                    ViewBag.Title = "Seleccion de Asignaturas";
                    wrapper.SeleccionState = 1; 
                    state = new SeleccionState();
                }

                state.ModificarSeleccionTemporal("G");
                EstudianteSeleccion data = CargarPagina(state);

                return View(data);
            }
            return RedirectToAction("Login", "Main");

        }

        public ActionResult GuardarOferta(string codigo, string codigoCorto, int tipo, int estudiante)
        {
            if (SimpleSecurity.HasStudent())
            {
                ViewBag.error = state.AgregarORemoverMateria(codigo, codigoCorto, tipo, estudiante);
                EstudianteSeleccion data = CargarPagina(state);

                return View("Index", data);
            }
            else
            {
                DescartarSeleccion(estudiante);
            }
            
            return RedirectToAction("Login", "Main");
        }

        public ActionResult Ofertas(string codArea)
        {
            OfertaAcademicaRepository repository = new OfertaAcademicaRepository();
            var result = repository.RetrieveAll().Where(m => m.CodigoArea == codArea).ToList();
            if (result == null)
            {
                return View(new List<OfertaAcademica>());
            }

            return View(result);
        }

        public ActionResult AgregarMateria(string codigo, int estudiante)
        {
            if (SimpleSecurity.HasStudent())
            {
                ViewBag.error = state.InsertarAsignatura(codigo, estudiante);
                EstudianteSeleccion data = CargarPagina(state);

                return View("Index", data);
            }
            else
            {
                DescartarSeleccion(estudiante);
            }
            
            return RedirectToAction("Login", "Main");
        }

        public ActionResult SalirSinGuardar(int estudiante)
        {
            if (SimpleSecurity.HasStudent())
            {
                state.ModificarSeleccionTemporal("S");
            }
            else
            {
                DescartarSeleccion(estudiante);
            }
            
            return RedirectToAction("Menu", "Main");
        }

        public ActionResult Guardar(int estudiante)
        {
            if (SimpleSecurity.HasStudent())
            {
                var result = state.ModificarSeleccionTemporal("E");
                if (result != "")
                {
                    ViewBag.ServerError = result;
                    EstudianteSeleccion data = CargarPagina(state);
                    return View("Index", data);
                }
                else 
                {
                    EnviarPDF("Seleccion");
                }
                
            }
            else
            {
                DescartarSeleccion(estudiante);
            }
            
            return RedirectToAction("Menu", "Main");
        }

        private void LimpiarMarcas(EstudianteSeleccion data)
        {
            foreach (var itemOferta in data.Oferta)
            {
                foreach (var itemSeleccion in data.Seleccion)
                {
                    if ((itemOferta.Codigo == itemSeleccion.Codigo && itemOferta.Tipo == itemSeleccion.Tipo)
                        && (itemSeleccion.EstatusTransaccion == EstatusTransaccion.Preregistered
                        || itemSeleccion.EstatusTransaccion == EstatusTransaccion.Current))
                    {
                        itemOferta.EstatusSeleccion = EstatusSeleccion.Seleccionada;
                    }
                }
            }
        }  

        private EstudianteSeleccion CargarPagina(SeleccionAbstractState state)
        {
            EstudianteSeleccion data = (EstudianteSeleccion) state.CargarEstudiante();

            ViewBag.Areas = new AreaRepository().RetrieveAll();
            LimpiarMarcas(data);
            return data;
        }

        private void DescartarSeleccion(int codigo)
        {
            JenzabarEntities entities = new JenzabarEntities();

            entities.GuardarPreseleccionTemporal(codigo, "S");
        }

        public ActionResult ObtenerPDF()
        {
            // First read in the report into memory.
            //ConfigurationManager.AppSettings["rptServer"].ToString()

            string strReportUser = ConfigurationManager.AppSettings["rptUser"].ToString();
            string strReportUserPW = ConfigurationManager.AppSettings["rptPassword"].ToString();
            string strReportUserDomain = ConfigurationManager.AppSettings["rptDomain"].ToString();
            string sTargetURL = ConfigurationManager.AppSettings["rptServer"].ToString() + "?" +
               "/JNZ/RE/Reporte Seleccion&rs:Command=Render&rs:Format=PDF&id=" + new SessionWrapper().Id;

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
            Estudiante estudiante = new EstudianteRepository().SearchById(new SessionWrapper().Id, TipoEstudiante.EstudianteRetiro);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader(
                "content-disposition",
                "attachment; filename=\"" +
                    estudiante.Nombre + " " +
                    estudiante.SegundoNombre + " " +
                    estudiante.Apellido + " - " +
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

            EstudianteSeleccion estudiante = (EstudianteSeleccion) new EstudianteRepository().
                SearchById(new SessionWrapper().Id, TipoEstudiante.EstudianteRetiro);

            string strReportUser = ConfigurationManager.AppSettings["rptUser"].ToString();
            string strReportUserPW = ConfigurationManager.AppSettings["rptPassword"].ToString();
            string strReportUserDomain = ConfigurationManager.AppSettings["rptDomain"].ToString();
            string sTargetURL = "";
            if (estudiante.ano != 0 && estudiante.Termino != 0)
            {
                sTargetURL = ConfigurationManager.AppSettings["rptServer"].ToString() + "?" +
                   "/JNZ/RE/" + reporte + "&rs:Command=Render&rs:Format=PDF" +
                   "&ID_NUM=" + estudiante.ID +
                   "&Term=" + estudiante.Termino +
                   "&Year=" + estudiante.ano;
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

            SmtpClient SMTPServer = new SmtpClient("192.168.0.22");
            MailMessage mailObj = new MailMessage("sistema.vriv@intec.edu.do", "raul.montero@intec.edu.do", "Reporte de seleccion", "Prueba");
            mailObj.Attachments.Add(new Attachment(fStream, new ContentType("application/pdf")));
            mailObj.IsBodyHtml = true;
            SMTPServer.Send(mailObj);

            HttpWResp.Close();
        }
    }
}