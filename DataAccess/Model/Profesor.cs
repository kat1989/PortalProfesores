using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{
    public class Profesor
    {
        public Profesor()
        {
            //Asignaturas = new List<AsignaturaPublicacion>();
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Area { get; set; }
        public string Trimestre { get; set; }
        public string Tipo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

        //public ICollection<AsignaturaPublicacion> Asignaturas { get; set; }
    }
}
