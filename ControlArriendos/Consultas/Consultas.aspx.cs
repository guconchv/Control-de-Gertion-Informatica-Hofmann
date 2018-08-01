using Negocios;
using Presentacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.IO;

namespace ControlArriendos
{
    public partial class Consultas : System.Web.UI.Page
    {
        string Fecha;
        string FechaDev;
        int Estado;
        int TipoEquipo;
        int Sucursal;
        int Cliente;
        int ruten;
        int RutTec;
        string IP;
        string cadenaConexion = MasterPage.CadenaConexion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFecha.Attributes.Add("readonly", "readonly");
                txt_fecdev.Attributes.Add("readonly", "readonly");
                LlenaDropDownList();
                LLenaGrilla();
                LlenarGrillaDev();
                LLenaGrillaEn();
                LlenaGrillaTecnicos();
                LlenaDropDownListDevolucion();
                LlenaDropDownListTecnicos();
                PanelPrincipal.Visible = true;
                PanelConsulta1.Visible = true;
                PanelConsulta2.Visible = false;
                PanelConsulta3.Visible = false;
                PanelTecnicos.Visible = false;
            }
        }

        //************************* fin funcionalidad para PanelConsulta1 **************************************//

        public void LlenaDropDownList()
        {
            DataTable estado = new DataTable();

            estado = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodEstadosGuias, cadenaConexion);

            DropEstado.DataSource = estado;
            DropEstado.DataValueField = "PAR_COD_PAR";
            DropEstado.DataTextField = "PAR_DES_PAR";
            DropEstado.DataBind();
            DropEstado.SelectedValue = "-1";

            DataTable TipoEquipo = new DataTable();

            TipoEquipo = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodTipoEquipo, cadenaConexion);

            DropEquipo.DataSource = TipoEquipo;
            DropEquipo.DataValueField = "PAR_COD_PAR";
            DropEquipo.DataTextField = "PAR_DES_PAR";
            DropEquipo.DataBind();
            DropEquipo.SelectedValue = "-1";

            //Prueba Andres

            DataTable RutCliente = new DataTable();

            RutCliente = PreparaAcceso.BuscarRutNomClientes(cadenaConexion);

            DropRutCliente.DataSource = RutCliente;
            DropRutCliente.DataValueField = "cli_rut_cli";
            DropRutCliente.DataTextField = "cli_nom_cli";
            DropRutCliente.DataBind();
            DropRutCliente.SelectedValue = "-1";

            //Fin Prueba Andres
        }
        public void LLenaGrilla()
        {
            Estado = Convert.ToInt32(DropEstado.SelectedValue);
            TipoEquipo = Convert.ToInt32(DropEquipo.SelectedValue);
            Fecha = txtFecha.Text;

            DataTable Buscar = new DataTable();
            Buscar = PreparaAcceso.BuscarLLenarConsulta(Fecha, Estado, TipoEquipo, IP, cadenaConexion);
            GrillaConsulta.DataSource = Buscar;
            GrillaConsulta.DataBind();
        }

        protected void Consulta1_Click(object sender, EventArgs e)
        {
            PanelConsulta1.Visible = true;
            PanelConsulta2.Visible = false;
            PanelConsulta3.Visible = false;
            PanelTecnicos.Visible = false;
        }

 
        protected void GrillaConsulta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GrillaConsulta.PageIndex = e.NewPageIndex;
            LLenaGrilla();
        }

        protected void GrillaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BuscarGuias_Click(object sender, EventArgs e)
        {
            LLenaGrilla();
        }

        //************************* fin funcionalidad para PanelConsulta1 **************************************//
       
        
        protected void Consulta2_Click(object sender, EventArgs e)
        {
            PanelConsulta1.Visible = false;
            PanelConsulta2.Visible = true;
            PanelConsulta3.Visible = false;
            PanelTecnicos.Visible  = false;
        }

        protected void Consulta3_Click(object sender, EventArgs e)
        {
            PanelConsulta1.Visible = false;
            PanelConsulta2.Visible = false;
            PanelConsulta3.Visible = true;
            PanelTecnicos.Visible  = false;
        }

        protected void btnTecnicos_Click(object sender, EventArgs e)
        {
            PanelConsulta1.Visible = false;
            PanelConsulta2.Visible = false;
            PanelConsulta3.Visible = false;
            PanelTecnicos.Visible = true;
        }

        protected void BtnInforme_Click(object sender, ImageClickEventArgs e)
        {
            if (GrillaConsulta.Rows.Count == 0)
            {
                Panel_mensaje.Visible = true;
                return;
            }

                Estado = Convert.ToInt32(DropEstado.SelectedValue);
                TipoEquipo = Convert.ToInt32(DropEquipo.SelectedValue);
                Fecha = txtFecha.Text;
                Session["Estado"] = Estado;
                Session["TipoEquipo"] = TipoEquipo;
                Session["Fecha"] = Fecha;
                Response.Redirect("~/Consultas/Informes/InformeConsultas.aspx");
            //}
        
        }



        protected void GVDevolucion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //************************* Funcionalidad para Consulta 2 **************************************//
        public void LlenarGrillaDev()
        {
                GVDevolucion.DataSource = PreparaAcceso.ObtenerDevoluciones(cadenaConexion);
                GVDevolucion.DataBind();  
        }

        protected void GVDevolucion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GVDevolucion.PageIndex = e.NewPageIndex;
            LlenarGrillaDev(); 
        }

        protected void btn_informedev_Click(object sender, ImageClickEventArgs e)
        {
            if (GVDevolucion.Rows.Count == 0)
            {
                PanelMsje.Visible = true;
                return;
            }

                Sucursal = Convert.ToInt32(DropSucursal.SelectedValue);
                Cliente = Convert.ToInt32(DropCliente.SelectedValue);
                FechaDev = txtFecha.Text;
                Session["Sucursal"] = Sucursal;
                Session["Cliente"] = Cliente;
                Session["FechaDev"] = FechaDev;
                Response.Redirect("~/Consultas/Informes/InformeDevoluciones.aspx");
            //}
        }
        public void LlenaDropDownListDevolucion()
        {
            DataTable sucursal = new DataTable();

            sucursal = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodSucursales, cadenaConexion);

            DropSucursal.DataSource = sucursal;
            DropSucursal.DataValueField = "PAR_COD_PAR";
            DropSucursal.DataTextField = "PAR_DES_PAR";
            DropSucursal.DataBind();
            DropSucursal.SelectedValue = "-1";

            DataTable cliente = new DataTable();

            cliente = PreparaAcceso.BuscarRutNomClientes(cadenaConexion);

            DropCliente.DataSource = cliente;
            DropCliente.DataValueField = "cli_rut_cli";
            DropCliente.DataTextField = "cli_nom_cli";
            DropCliente.DataBind();
            DropCliente.SelectedValue = "-1";
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
                Sucursal = Convert.ToInt32(DropSucursal.SelectedValue);
                Cliente = Convert.ToInt32(DropCliente.SelectedValue);
                FechaDev = txt_fecdev.Text;

                DataTable BuscarDev = new DataTable();
                BuscarDev = PreparaAcceso.BuscarDevoluciones(FechaDev, Sucursal, Cliente,cadenaConexion);
                GVDevolucion.DataSource = BuscarDev;
                GVDevolucion.DataBind();
        }


        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            DropEstado.SelectedValue = "-1";
            DropEquipo.SelectedValue = "-1";
            DropRutCliente.SelectedValue = "-1";
            LLenaGrilla();
            LlenarGrillaDev();
            LLenaGrillaEn();
        }

        protected void btn_limpiardev_Click(object sender, EventArgs e)
        {
            txt_fecdev.Text = "";
            DropCliente.SelectedValue = "-1";
            DropSucursal.SelectedValue = "-1";
            DropRutCliente.SelectedValue = "-1";
            LLenaGrilla();
            LlenarGrillaDev();
            LLenaGrillaEn();
        }


        //************************* fin funcionalidad para PanelConsulta2 **************************************//
        //************************* Funcionalidad para Consulta 3 **************************************//
        public void LLenaGrillaEn()
        {
                ruten = Convert.ToInt32(DropRutCliente.SelectedValue);

                DataTable Buscaren = new DataTable();
                Buscaren = PreparaAcceso.BuscarEnsamble(ruten, cadenaConexion);
                GrillaEnsamble.DataSource = Buscaren;
                GrillaEnsamble.DataBind();
            //}
        }

        protected void btn_informe_ens_Click(object sender, ImageClickEventArgs e)
        {
            if (GrillaEnsamble.Rows.Count == 0)
            {
                PanelMsje1.Visible = true;
                return;
            }

                    Session["ruten"] = Convert.ToInt32(DropRutCliente.SelectedValue);
                    Response.Redirect("~/Consultas/Informes/InformeListarEnsamble.aspx");

            //    }
            //}

        }

        protected void btn_buscar_en_Click(object sender, EventArgs e)
        {

            ruten = Convert.ToInt32(DropRutCliente.SelectedValue);

            DataTable Buscaren = new DataTable();
            Buscaren = PreparaAcceso.BuscarEnsamble(ruten, cadenaConexion);
            GrillaEnsamble.DataSource = Buscaren;
            GrillaEnsamble.DataBind();

        }

        protected void btn_limpiarens_Click(object sender, EventArgs e)
        {
            txt_fecdev.Text = "";
            DropCliente.SelectedValue = "-1";
            DropSucursal.SelectedValue = "-1";
            DropRutCliente.SelectedValue = "-1";
            DropDownListTecnicos.SelectedValue = "-1";
            LLenaGrilla();
            LlenarGrillaDev();
            LLenaGrillaEn();
            LlenaGrillaTecnicos();
            PanelMsje1.Visible = false;
        }
        //************************* fin funcionalidad para PanelConsulta3 **************************************//

        //**************************Inicio Funcionalidad para PanelTecnicos ***********************GUSTAVO******//


        public void LlenaDropDownListTecnicos()
        {
            DataTable Tecnico = new DataTable();

            Tecnico = PreparaAcceso.BuscarIdeNomTecnicos(cadenaConexion);

            DropDownListTecnicos.DataSource = Tecnico;
            DropDownListTecnicos.DataValueField = "tec_rut_tec";
            DropDownListTecnicos.DataTextField = "tec_nom_tec";
            DropDownListTecnicos.DataBind();
            DropDownListTecnicos.SelectedValue = "-1";
        }

        public void LlenaGrillaTecnicos()
        {
            DataTable BuscaTecnico = new DataTable();
            BuscaTecnico = PreparaAcceso.BuscarNomTecnicos(cadenaConexion);
            GridTecnicos.DataSource = BuscaTecnico;
            GridTecnicos.DataBind();
        }


        protected void btn_BuscarTecnicos_Clic(object sender, EventArgs e)
        {
            RutTec = Convert.ToInt32(DropDownListTecnicos.SelectedValue);

            DataTable BuscaRutTecnico = new DataTable();
            BuscaRutTecnico = PreparaAcceso.BuscarTecnicoRut(RutTec, cadenaConexion);
            GridTecnicos.DataSource = BuscaRutTecnico;
            GridTecnicos.DataBind();
        }

        protected void btn_Imprimir_Tecnicos_Click(object sender, ImageClickEventArgs e)
        {
            if (GridTecnicos.Rows.Count == 0)
            {
                Panel_mensaje.Visible = true;
                return;
            }


            Session["rut"] = Convert.ToInt32(DropDownListTecnicos.SelectedValue);
            Response.Redirect("~/Consultas/Informes/InformeTecnicos.aspx");
        }
    }
}