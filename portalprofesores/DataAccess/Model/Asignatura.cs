using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{
    public class Asignatura
    {
        public int IdEstudiante { get; set; }
        public string CodigoCompleto { get; set; }
        public string Codigo { get; set; }
        public string Seccion { get; set; }
        public string Estado { get; set; }
        public int TotalAsignaturas { get; set; }
        public DateTime FechaClave { get; set; }
        public int? IdRevison { get; set; }
        public string Nombre { get; set; }
        public string Calificacion { get; set; }
        public EstadoRevision EstadoRevision { get; set; }
        public int IdEstadoRevision { get; set; }
        public string Trimestre { get; set; }
        public int ProfesorId { get; set; }
        public string ProfesorNombre { get; set; }
        public double PorcentajeRevisionAbierta { get; set; }
        public EstadosSolictudRevision EstadoSolicitud { get; set; }
        public DateTime? FechaRevisionSolicitada { get; set; }
        public DateTime? FechaEstatus { get; set; }
        public DateTime? FechaAgendada { get; set; }
        public string Ano { get; set; }
        public string CodigoTrimestre { get; set; }
        public Revision Revision { get; set; }

    }

    public enum EstadosSolictudRevision
    {
        Normal,
        Moderado,
        Critico
    }
}
