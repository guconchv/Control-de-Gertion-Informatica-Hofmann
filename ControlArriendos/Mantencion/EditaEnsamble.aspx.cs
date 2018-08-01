﻿using Negocios;
using Presentacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlArriendos.Mantencion
{
    public partial class EditaEnsamble : System.Web.UI.Page
    {
        string CadenaConexion = MasterPage.CadenaConexion;
        string NroHoja;
        string RutCliente;
        DateTime Fecha;
        string TipoEquipo;
        string Venta;
        string Tecnico;
        string CodigoEstado;
        string Usuario;
        string NHoja;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LLenaCombos();
                LLenaInfoEnsamble();
                RefreshData();
                GridP.Visible = true;
            }
        }
        public void LLenaCombos()
        {
            //DateTime localDate = DateTime.Now;
            //Calendar1.SelectedDate = localDate;
            txt_fecha.Attributes.Add("readonly", "readonly");

            DataTable IdTecnico = new DataTable();

            IdTecnico = PreparaAcceso.BuscarIdeNomTecnicos(CadenaConexion);
            DropTecnico.DataSource = IdTecnico;
            DropTecnico.DataValueField = "tec_rut_tec";
            DropTecnico.DataTextField = "tec_rut_tec";
            DropTecnico.DataBind();

            //Prueba Andres
            DataTable TipoEquipo = new DataTable();

            TipoEquipo = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodTipoEquipo, CadenaConexion);
            DropTipoEquipo.DataSource = TipoEquipo;
            DropTipoEquipo.DataValueField = "PAR_COD_PAR";
            DropTipoEquipo.DataTextField = "PAR_DES_PAR";
            DropTipoEquipo.DataBind();
            //Fin Prueba Andres

        }
        public void LLenaInfoEnsamble()
        {
            DataTable lector = new DataTable();
            lector = PreparaAcceso.BuscarCabeceraPorNroHoja(Convert.ToDecimal(Request.QueryString["ID"]), CadenaConexion);

            //  ******************  Llenado TextBox   *************************
            this.txtNhoja.Text = lector.Rows[0][0].ToString();
            txtNhoja.Enabled = false;
            this.txtNombre.Text = lector.Rows[0][1].ToString();
            txtNombre.Enabled = false;
            this.DropTipoEquipo.Text = lector.Rows[0][3].ToString();
            //this.txtEquipo.Text = lector.Rows[0][3].ToString();
            this.txtVenta.Text = lector.Rows[0][4].ToString().ToLower();
            //Llenado de fechas
            this.txt_fecha.Text = Convert.ToDateTime(lector.Rows[0][2]).ToString("dd/MM/yyyy");
           // this.Calendar1.SelectedDate = Convert.ToDateTime(lector.Rows[0][2]);
            //*******************************Iniciacion de combos
            DropTecnico.SelectedIndex = Convert.ToInt32(lector.Rows[0][5].ToString());


        }
        public void RefreshData()
        {
            try
            {
                GridP.DataSource = PreparaAcceso.BuscarDetallePorNroHoja(Convert.ToDecimal(Request.QueryString["ID"]), CadenaConexion);
                GridP.DataBind();
            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
        protected void ActualizarRegistro(object sender, GridViewEditEventArgs e)
        {
            GridP.EditIndex = e.NewEditIndex;
            RefreshData();

            DropDownList DropHardware = GridP.Rows[e.NewEditIndex].FindControl("DropHardware") as DropDownList;
            DataTable Hardware1 = new DataTable();
            Hardware1 = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodTipoHardware, CadenaConexion);

            DropHardware.DataSource = Hardware1;
            DropHardware.DataValueField = "par_cod_par";
            DropHardware.DataTextField = "par_des_par";
            DropHardware.DataBind();
            Label lblhardware = GridP.Rows[e.NewEditIndex].FindControl("lblHrw") as Label;
            DataTable lector1 = new DataTable();
            lector1 = PreparaAcceso.BuscaCodigoParametrosPorNombre(lblhardware.Text, CadenaConexion);
            DropHardware.SelectedValue = lector1.Rows[0][0].ToString();
        }
        protected void Update_Registro(object sender, GridViewUpdateEventArgs e)
        {

            try
            {

                Tabla_Detalle Obj = new Tabla_Detalle();
                NHoja = this.txtNhoja.Text;
                Obj.NroHoja = Convert.ToDecimal(NHoja);
                Obj.Cor = Convert.ToInt32(((System.Web.UI.WebControls.Label)GridP.Rows[e.RowIndex].Cells[0].Controls[1]).Text);
                Obj.CodigoHrw = Convert.ToInt32(((System.Web.UI.WebControls.DropDownList)GridP.Rows[e.RowIndex].Cells[1].Controls[1]).Text);
                Obj.Serie = Convert.ToString(((System.Web.UI.WebControls.TextBox)GridP.Rows[e.RowIndex].Cells[4].Controls[1]).Text);
                Obj.Marca = Convert.ToString(((System.Web.UI.WebControls.TextBox)GridP.Rows[e.RowIndex].Cells[2].Controls[1]).Text);
                Obj.Modelo = Convert.ToString(((System.Web.UI.WebControls.TextBox)GridP.Rows[e.RowIndex].Cells[3].Controls[1]).Text);
                Obj.Observacion = Convert.ToString(((System.Web.UI.WebControls.TextBox)GridP.Rows[e.RowIndex].Cells[5].Controls[1]).Text);
                DataTable ActualizaDetalle = new DataTable();
                ActualizaDetalle = PreparaAcceso.ModificarEnsambleDetalle(Obj.NroHoja, Obj.Cor, Obj.CodigoHrw, Obj.Serie, Obj.Marca, Obj.Modelo, Obj.Observacion, CadenaConexion);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<SCRIPT LANGUAGE='javascript'> alert('Ensamble actualizado correctamente!!.');</SCRIPT>");
                GridP.EditIndex = -1;
                RefreshData();

            }
            catch (Exception exp)
            {
                Response.Write(exp.Message);
            }

        }
        protected void CancelarRegistro(object sender, GridViewCancelEditEventArgs e)
        {
            GridP.EditIndex = -1;
            RefreshData();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridP.PageIndex = e.NewPageIndex;
        }
        protected void GridP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ActualizarCabecera_Click(object sender, EventArgs e)
        {
            if (DropTecnico.SelectedValue != "-1")
            {
                TipoEquipo = DropTipoEquipo.SelectedValue;
                //TipoEquipo = txtEquipo.Text;
                NroHoja = txtNhoja.Text;
                Venta = txtVenta.Text;
                CodigoEstado = "1";
                Usuario = Session["NomUsuario"].ToString();
                Fecha = Convert.ToDateTime(txt_fecha.Text);
                //Fecha = Calendar1.SelectedDate;
                Tecnico = DropTecnico.SelectedValue;



                string[] array = new string[] { TipoEquipo, Venta, Convert.ToString(Fecha), Usuario };

                if (PreparaAcceso.funsionValFormVacios(array))
                {
                    PreparaAcceso.ModificaEnsambleCabecera(Convert.ToDecimal(NroHoja), Fecha, Convert.ToInt32(TipoEquipo), Venta, Tecnico, Convert.ToInt32(CodigoEstado), Usuario, CadenaConexion);

                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<SCRIPT LANGUAGE='javascript'> alert('La Cabecera fue Actualizada Correctamente!');</SCRIPT>");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<SCRIPT LANGUAGE='javascript'> alert('Complete Los Campos Que Estan vacios!');</SCRIPT>");
                }
            }
            else
            {
                Response.Write("<script >alert('Verifique Seleccion de Tecnico ');</script>");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}