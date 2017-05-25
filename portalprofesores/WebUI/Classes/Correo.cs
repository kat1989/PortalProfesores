using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace WebUI.Classes
{
    public class Correo
    {
        public string Direccion { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public Attachment[] ArchivosAdjuntos { get; set; }
    }
}
