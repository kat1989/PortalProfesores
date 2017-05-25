using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Classes;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using WebUI.Helpers;

namespace WebUI.Views.Shared
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var reporteId = Request.QueryString["r"];
                if (!String.IsNullOrEmpty(reporteId))
                {
                    int id = 0;
                    int.TryParse(reporteId, out id);
                    var reporte = new ManejadorReporte(id).ObtenerReporte();
                    var profesorId = WrapperSession.ObtenerInstancia().Id;

                    rptViewer.ServerReport.ReportServerCredentials = new MyReportServerCredentials();
                    rptViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["rptServer"].ToString());
                    rptViewer.ServerReport.ReportPath = reporte.Ruta;
                    rptViewer.ServerReport.SetParameters(new ReportParameter("PROFESOR",profesorId));
                    //rptViewer.ServerReport.
                }
            }
        }
    }
}