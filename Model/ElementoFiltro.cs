using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    public class ElementoFiltro
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string ValorDefecto { get; set; }
        public int TotalRegistros { get; set; }
    }
}