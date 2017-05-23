using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using WebUI.Classes;

namespace WebUI.Classes
{
    public class EnviadorCorreo
    {
        public void Enviar(Correo correo)
        {
            try
            {
                if (!String.IsNullOrEmpty(correo.Direccion))
                {
                    SmtpClient SMTPServer = new SmtpClient("192.168.0.22");
                    MailMessage mailObj = new MailMessage("notificacion@intec.edu.do", correo.Direccion, correo.Titulo, correo.Contenido);

                    foreach (var item in correo.ArchivosAdjuntos)
                    {
                        mailObj.Attachments.Add(item);
                    }

                    mailObj.IsBodyHtml = true;
                    SMTPServer.Send(mailObj);
                }
            }
            catch (Exception) { }
        }
    }
}
