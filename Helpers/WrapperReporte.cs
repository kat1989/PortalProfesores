using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebUI.Helpers
{
    public class WrapperReporte
    {
        private static WrapperReporte instancia;

        private WrapperReporte() { }

        public static WrapperReporte GetInstance()
        {
            if (instancia == null)
            {
                instancia = new WrapperReporte();
            }

            return instancia;
        }

        public ReportElement ObtenerDataReporte(string indice)
        {
            return ReportCenterConfiguration.Instance.Reports[indice];
        }
    }    
}
