using Microsoft.Reporting.WebForms;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlArriendos.Mantencion.Informes
{
    public partial class InformeListEnsamble : System.Web.UI.Page
    {
        string cadenaConexion = MasterPage.CadenaConexion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mostrar();
            }
        }

        private void Mostrar()
        {
            InformeListarEnsamble.Reset();//Reseteamos el Reporte
            DataTable dsC = PreparaAcceso.BuscarEnsamble(Convert.ToInt32(Session["ruten"]), cadenaConexion);     //.LLenarConsultaGuia(cadenaConexion); //Con este datatable capturaremos el dato retornado para nuestro parametro
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsC);// nombre del dataset(que guardara los datos+datatable que trae el parametro 
            InformeListarEnsamble.LocalReport.DataSources.Add(datasource);//Le decimos que el reporte es de tipo local
            InformeListarEnsamble.LocalReport.ReportPath = Server.MapPath("Reportes/ReporteEnsamble.rdlc"); //se mapea la direccion de nuestro reporte dentro del proyecto.
            //ReportParameter prm = new ReportParameter("Suc", Session["Codsuc"].ToString());
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm });
            InformeListarEnsamble.LocalReport.Refresh();//para refrescar el reporte
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Consultas/Consultas.aspx");
        }
    }
}