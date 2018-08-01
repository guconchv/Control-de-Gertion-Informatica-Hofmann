﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using Presentacion;

namespace ControlArriendos
{
    public partial class Guias : System.Web.UI.Page
    {
        string cadenaConexion = MasterPage.CadenaConexion;
        int NumGuia;
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    pMsjGuia.Visible = false;
                    Panel_mensaje.Visible = false;
                    DataTable sucursal = new DataTable();
                    sucursal = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodSucursales, cadenaConexion);

                    DropSucursal.DataSource = sucursal;
                    DropSucursal.DataValueField = "PAR_COD_PAR";
                    DropSucursal.DataTextField = "PAR_DES_PAR";
                    DropSucursal.DataBind();
                    DropSucursal.SelectedValue = "-1";


                    DataTable estado = new DataTable();

                    estado = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodEstadosGuias, cadenaConexion);

                    DropEstado.DataSource = estado;
                    DropEstado.DataValueField = "PAR_COD_PAR";
                    DropEstado.DataTextField = "PAR_DES_PAR";
                    DropEstado.DataBind();
                    DropEstado.SelectedValue = "-1";

                    DataTable rutcliente = new DataTable();

                    rutcliente = PreparaAcceso.BuscarRutNomClientes(cadenaConexion);

                    DropRutCliente.DataSource = rutcliente;
                    DropRutCliente.DataValueField = "cli_rut_cli";
                    DropRutCliente.DataTextField = "cli_nom_cli";
                    DropRutCliente.DataBind();
                    DropRutCliente.SelectedValue = "-1";
                   

                    LlenaGrillaGuias();

                }
        }
         public void LlenaGrillaGuias()
        {
            
            int RutCliente = Convert.ToInt32(DropRutCliente.SelectedValue);
            int Sucursal = Convert.ToInt16(DropSucursal.SelectedValue);
            int Estado = Convert.ToInt16(DropEstado.SelectedValue);
            if (tbxNumGuia.Text == "")
            {
                NumGuia = 0;
                pMsjGuia.Visible = true;
            }
            else
            {
                NumGuia = Convert.ToInt32(tbxNumGuia.Text);
            }
                    
            GVGuias.DataSource = PreparaAcceso.BuscadatosGuiasGrid(cadenaConexion,NumGuia,RutCliente,Sucursal,Estado);
            GVGuias.DataBind();
        }

         

         ///paginacion !!!!!!!!!!!!!!!!!!!!!!!!!!!
         protected void GVGuias_PageIndexChanging(object sender, GridViewPageEventArgs e)
         {
             this.GVGuias.PageIndex = e.NewPageIndex;
               LlenaGrillaGuias();
         }

         protected void GVGuias_SelectedIndexChanged(object sender, EventArgs e)
         {

         }

         protected void IngresarGuia_Click(object sender, EventArgs e)
         {
             Response.Redirect("Guias_Agreg.aspx");
         }

         protected void imgImforme_Click(object sender, ImageClickEventArgs e)
         {
             if (GVGuias.Rows.Count == 0)
             {
                 Panel_mensaje.Visible = true;
                 return;
             }
             if (tbxNumGuia.Text == "")
             {
                 NumGuia = 0;
             }
             else
             {
                 NumGuia = Convert.ToInt32(tbxNumGuia.Text);
             }

             Session["numguia"]     = NumGuia;
             Session["rutcliente"]  = DropRutCliente.SelectedValue;
             Session["sucursal"]    = DropSucursal.SelectedValue;
             Session["estado"]      = DropEstado.SelectedValue;
             //Response.Redirect("informes/informe_guias.aspx?NumG=" + NumGuia + "&RutCli=" + DropRutCliente.SelectedValue + "&Suc=" + DropSucursal.SelectedValue + "&Est=" + DropEstado.SelectedValue);
             Response.Redirect("informes/informe_guias.aspx");

             //Response.Redirect("informes/informe_guias.aspx");
         }

         protected void btnBuscar_Click(object sender, EventArgs e)
         {
             Panel_mensaje.Visible = false;
             LlenaGrillaGuias();
         }


        
    }
}