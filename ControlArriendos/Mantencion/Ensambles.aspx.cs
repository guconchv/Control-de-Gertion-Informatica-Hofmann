using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlArriendos
{
    public partial class Ensambles : System.Web.UI.Page
    {
        Decimal Rut;
        string Fecha;
        string CadenaConexion = MasterPage.CadenaConexion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable rutcliente = new DataTable();

                rutcliente = PreparaAcceso.BuscarRutNomClientes(CadenaConexion);

                DropRutCliente.DataSource = rutcliente;
                DropRutCliente.DataValueField = "cli_rut_cli";
                DropRutCliente.DataTextField = "cli_nom_cli";
                DropRutCliente.DataBind();
                DropRutCliente.SelectedValue = "-1";
                   
                BuscarListaEnsamble();
                GridView1.Visible = true;
                PanelMsje.Visible = false;
                Panelinforme.Visible = false;
            }
        }

        public void BuscarListaEnsamble()
        {
            DataTable ensambles = new DataTable();
            Fecha = (!String.IsNullOrEmpty(txtFecha.Text)) ? txtFecha.Text : "";
            Rut   = (Convert.ToInt32(DropRutCliente.SelectedValue) > 0) ? Convert.ToInt32(DropRutCliente.SelectedValue) : 0;
            ensambles = PreparaAcceso.BuscarEnsamblePorRutFecha(Rut, Fecha, CadenaConexion);
            GridView1.DataSource = ensambles;
            //GridView1.DataSource = PreparaAcceso.LLenarListaEnsamble(CadenaConexion);
            GridView1.DataBind();
        }

        protected void BuscarEnsamble_Click(object sender, EventArgs e)
        {

            BuscarListaEnsamble();

        }
        protected void GVEnsambles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            BuscarListaEnsamble();
        }

        protected void GVEnsambles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void NuevoEnsamble_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantencion/NuevoEnsamble.aspx");
        }

        protected void InformeEnsamble_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                Panelinforme.Visible = true;
                return;
            }
                Fecha = (!String.IsNullOrEmpty(txtFecha.Text)) ? txtFecha.Text : "";
                Rut = (Convert.ToInt32(DropRutCliente.SelectedValue) > 0) ? Convert.ToInt32(DropRutCliente.SelectedValue) : 0;
                Session["RutCliente"] = Rut;
                Session["Fecha"] = Fecha;
                Response.Redirect("~/Mantencion/Informes/InformeEnsambles.aspx");
            //}
        }
    }
}