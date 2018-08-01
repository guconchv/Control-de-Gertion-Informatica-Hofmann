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
    public partial class InformeDevoluciones : System.Web.UI.Page
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

            ReportViewer1.Reset();//Reseteamos el Reporte
            DataTable dsC = PreparaAcceso.BuscarDevoluciones(Convert.ToString(Session["FechaDev"]), Convert.ToInt32(Session["Sucursal"]), Convert.ToInt32(Session["Cliente"]),cadenaConexion);     //.LLenarConsultaGuia(cadenaConexion); //Con este datatable capturaremos el dato retornado para nuestro parametro
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsC);// nombre del dataset(que guardara los datos+datatable que trae el parametro 
            ReportViewer1.LocalReport.DataSources.Add(datasource);//Le decimos que el reporte es de tipo local
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reportes/ReportDevoluciones.rdlc"); //se mapea la direccion de nuestro reporte dentro del proyecto.
            //ReportParameter prm = new ReportParameter("Suc", Session["Codsuc"].ToString());
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm });
            ReportViewer1.LocalReport.Refresh();//para refrescar el reporte
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Consultas/Consultas.aspx");
        }
    }
}