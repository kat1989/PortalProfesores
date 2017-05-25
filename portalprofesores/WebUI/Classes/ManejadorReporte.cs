using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebUI.Helpers;
using Seleccion.Helpers;
using DataAccess;
using System.IO;
//using Seleccion.Classes;
using Seleccion;

namespace WebUI.Classes
{
    public class ManejadorReporte
    {
        private Reporte reporte;

        public ManejadorReporte(int id)
        {
            int idReporte = 0;
            var dataReporte = ReportCenterConfiguration.Instance.Reports[id];
            int.TryParse(dataReporte.Id, out idReporte);

            reporte = new Reporte()
            {
                Id = idReporte,
                Nombre = dataReporte.Name,
                Ruta = dataReporte.Direccion,
                Visualizacion = dataReporte.Visualization,
                Parametros = new Dictionary<string,string>()
            };
        }

        public Reporte ObtenerReporte()
        {
            return reporte;
        }
    }
}
