using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net.Mail;

namespace Logger
{
    public class EventLogger : ILogger
    {
        private string appName;

        public EventLogger(string appName) 
        {
        //    if (!EventLog.SourceExists(appName))
        //        EventLog.CreateEventSource(appName, "Application");    
        //    this.appName = appName;
        }

        public void Debug(string text)
        {
            EventLog.WriteEntry(appName, text, EventLogEntryType.Information);
        }

        public void Warn(string text)
        {
            EventLog.WriteEntry(appName, text, EventLogEntryType.Warning);
        }

        public void Error(string text)
        {
            //EventLog.WriteEntry(appName, text, EventLogEntryType.Error);
            try
            {
                SmtpClient SMTPServer = new SmtpClient("192.168.0.22");
                MailMessage mailObj = new MailMessage("notificacion@intec.edu.do", "Aplicaciones@intec.edu.do", "Error App Publicacion",text);                
                mailObj.IsBodyHtml = true;
                SMTPServer.Send(mailObj);
            }
            catch (Exception) { }
        }

        public void Error(string text, Exception ex)
        {
            Error(text);
            Error(ex.StackTrace);
        }
    }
}
