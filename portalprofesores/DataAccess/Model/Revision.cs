using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Model;


namespace DataAccess.Model
{
   public  class Revision
    {
       public int RevisionId { get; set; }
       public int EstudianteId { get; set; }
     
       public string Estado { get; set; }
       public int ElementoRevisionId { get; set; }
       public List<ElementoRevision> ElementosRevision { get; set; }
       public string ComentarioEstudiante { get; set; }
       public string ComentarioAcedemcio { get; set; }
       public  string CodigoNota { get; set; }
       public string CodigoNotaAnterior { get; set; }
       public double? NotaAsignada { get; set; }
       public string LugarDisponible { get; set; }
       public int ProfesorId { get; set; }
       public int? RepresentanteId { get; set; }
       public int? DocenteId { get; set; }
       public string Comentarios { get; set; }
       public DateTime? FechaCita { get; set; }
       public bool? ProfesorAsistio { get; set; }
       public bool? RepresentanteAsistio { get; set; }
       public bool? EstudianteAsistio { get; set; }
       public int IdEstado{get;set;}
       public DateTime FechaClave { get; set; }
       public string MotivoRevision { get; set; }
       public string EstudianteNombre { get; set; }
       public string NombreAsignatura { get; set; }
       public string ProfesorNombre { get; set; }
       public string CodigoAsignatura { get; set; }
       public string Carrera { get; set; }
       public string Area { get; set; }
       public string Trimestre { get; set; }
       public string Ano { get; set; }
       public string CorreoEstudiante { get; set; }
       public double PuntajeAsignado { get; set; }
       public double PuntajeObtenido { get; set; }
       public string CodigoDivision { get; set; }
       public string ElementoRevision { get; set; }
       public int CantidadSolicitadas { get; set; }
       public int CantidadAgendadas { get; set; }
       public int CantidadDeclinadas { get; set; }
       public int CantidadCerradas { get; set; }
       public int CantidadProcedeCambio { get; set; }

    }
}
