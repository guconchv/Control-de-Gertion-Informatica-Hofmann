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

namespace ControlArriendos
{
    public partial class InformeTecnicos : System.Web.UI.Page
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
            ReportViewer1.Reset();
            DataTable dsC = PreparaAcceso.BuscarTecnicoRut(Convert.ToInt32(Session["rut"]), cadenaConexion);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsC);
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reportes/ReporteTecnicos.rdlc");
            ReportViewer1.LocalReport.Refresh();
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Consultas/Consultas.aspx");
        }

    }
}