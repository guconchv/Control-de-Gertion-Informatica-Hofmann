using Microsoft.Reporting.WebForms;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlArriendos.Mantencion.Informes
{
    public partial class InformeParametros : System.Web.UI.Page
    {
        string CadenaConexion = MasterPage.CadenaConexion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mostrar();
            }
        }

        private void Mostrar()
        {
            ReportViewer1.Reset();//Reseteamos el Reporte
            DataTable dsC = PreparaAcceso.BuscaNombreParametrosPadre(Convert.ToInt16(Session["Codigo"]), CadenaConexion);//Con este datatable capturaremos el dato retornado para nuestro parametro
            DataTable dsC1 = PreparaAcceso.BuscaListaParmetrosInfCompletaPorCodigo(Convert.ToInt16(Session["Codigo"]), CadenaConexion);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsC);// nombre del dataset(que guardara los datos+datatable que trae el parametro 
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", dsC1);
            ReportViewer1.LocalReport.DataSources.Add(datasource);//Le decimos que el reporte es de tipo local
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reportes/ReportParametros.rdlc"); //se mapea la direccion de nuestro reporte dentro del proyecto.
            //ReportParameter prm = new ReportParameter("Codigo", Convert.ToInt16(Session["Codigo"]).ToString());
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm });
            ReportViewer1.LocalReport.Refresh();//para refrescar el reporte
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../Parametros.aspx");
        }
    }
}