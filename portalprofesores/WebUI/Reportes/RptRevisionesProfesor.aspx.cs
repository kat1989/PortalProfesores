using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Reportes
{
    public partial class RptRevisionesProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["profesorId"] != null)
                {
                    ProcesarReporte();
                }
            }

        }

        private void ProcesarReporte()
        {
            var profesorId =Request.QueryString["profesorId"] == string.Empty ?0:
                Convert.ToInt32(Request.QueryString["profesorId"]);
            var trimestre = Request.QueryString["trimestre"] == string.Empty ? null : Request.QueryString["trimestre"];
            var area = Request.QueryString["area"] == string.Empty ? null : Request.QueryString["area"];
            var ano = Request.QueryString["ano"] == string.Empty ? null : Request.QueryString["ano"];
            var trimestreText = Request.QueryString["trimestreText"];
            var anoText = Request.QueryString["anoText"];
            var filtroGeneralText = Request.QueryString["filtroCondicional"];
            var tipo=Request.QueryString["tipo"];

            rptViewer.Reset();
         
            rptViewer.LocalReport.ReportPath = Server.MapPath("/Reportes/RptRevisionProfesor.rdlc");
         
            rptViewer.LocalReport.DataSources.Clear();
            ReportParameter[] parametros = new ReportParameter[]{
               new ReportParameter("tipo",tipo),
               new ReportParameter("trimestre",trimestreText),
                new ReportParameter("ano",anoText),
                 new ReportParameter("filtroCondicional",filtroGeneralText)

           };
            rptViewer.LocalReport.SetParameters(parametros);
            if (tipo.Equals("1"))
                
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",
                new Helpers.RevisionNotaHelper().ObtenerReporteRevisionesProfesor(profesorId,area,ano,trimestre)));
            else
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",
                               new Helpers.RevisionNotaHelper().ObtenerReporteRevisionesArea(area, profesorId, ano, trimestre)));
            rptViewer.DataBind();
            rptViewer.LocalReport.Refresh();

        }
    }
}