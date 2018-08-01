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
    public partial class Clientes : System.Web.UI.Page
    {
        Decimal Rut;
        string Nombre;
        string CadenaConexion = MasterPage.CadenaConexion;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BuscarListaCliente();
                GridP.Visible = true;
                PanelMsje.Visible = false;
                Panel_mensaje.Visible = false;
            }
        }

        //------LLeno la grilla con dependiendo el codigo de sucursal
        public void BuscarListaCliente()
        {
            Nombre = (!String.IsNullOrEmpty(txtNombre.Text)) ? txtNombre.Text : "";
            Rut = (!String.IsNullOrEmpty(txtRut.Text)) ? Convert.ToDecimal(txtRut.Text) : 0;
            DataTable Buscar = new DataTable();
            Buscar = PreparaAcceso.BuscarCliente(Rut, Nombre, CadenaConexion);
            GridP.DataSource = Buscar;
            GridP.DataBind();
        }

        //------Redireccionamiento a modulos de empleados por rut
        protected void BuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarListaCliente();
               
        }

        ///-----Paginacón de la grilla
        protected void GridP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridP.PageIndex = e.NewPageIndex;
            BuscarListaCliente();
        }

        //------Exportar el Informe de Clientes
        protected void LLenarInforme_Click(object sender, ImageClickEventArgs e)
        {
            if (GridP.Rows.Count == 0)
            {
                Panel_mensaje.Visible = true;
                return;
            }
            
            Nombre = (!String.IsNullOrEmpty(txtNombre.Text)) ? txtNombre.Text : "";
            Rut = (!String.IsNullOrEmpty(txtRut.Text)) ? Convert.ToDecimal(txtRut.Text) : 0;
            Session["RutCliente"]= Rut;
            Session["NombreCliente"] = Nombre;
            Response.Redirect("~/Mantencion/Informes/Informe_Cliente.aspx");
        }

        protected void GridP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void NuevoCliente_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Mantencion/NuevoCliente.aspx");
        }
    }
}