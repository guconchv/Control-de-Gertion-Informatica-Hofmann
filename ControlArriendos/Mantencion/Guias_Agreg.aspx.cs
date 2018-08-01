﻿using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentacion;
namespace ControlArriendos.Mantencion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cadenaConexion = MasterPage.CadenaConexion;
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string NombreUsuario = Session["NomUsuario"].ToString();
           
            
            if (!IsPostBack)
            {
                //DateTime localDate = DateTime.Now;
                //clrGuia.SelectedDate = localDate;
                txt_fecha.Attributes.Add("readonly", "readonly");
                txt_fecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
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

                DataTable TipoEquipo = new DataTable();

                TipoEquipo = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodTipoEquipo, cadenaConexion);

                DropTipoEquipo.DataSource = TipoEquipo;
                DropTipoEquipo.DataValueField = "PAR_COD_PAR";
                DropTipoEquipo.DataTextField = "PAR_DES_PAR";
                DropTipoEquipo.DataBind();
                DropTipoEquipo.SelectedValue = "-1";
                tbxUsrResponsable.Text = NombreUsuario;
                tbxUsrResponsable.Enabled = false;

            }
        }
        protected void ButtoningresarGuia_Click(object sender, EventArgs e)
        {
            if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                int rutcliente 				= Convert.ToInt32(DropRutCliente.SelectedValue);
                string nomusuario 			= tbxNomUsuario.Text;
                string CueServidor 			= tbxCuenServidor.Text;
                string passServidor 		= tbxPassServidor.Text;
                string numserie 			= tbxNumSerie.Text;
                string sisasignado 			= tbxSisAsignados.Text;
                int sucursal 				= Convert.ToInt16(DropSucursal.SelectedValue);
                string nomequipo 			= tbxNomEquipo.Text;
                string descripcion 			= tbxDescripcion.Text;
                string dirrecionip 			= tbxDirrecionIp.Text;
                string sisoperativo 		= tbxSistemaOper.Text;
                string antivirus 			= tbxAntivirus.Text;
                string office 				= tbxoffice.Text;
                string idteamviewer 		= tbxIdTeamviewer.Text;
                string passteamviewer 		= tbxPassTeamviewer.Text;
                //string fecha 				= txt_fecha.Text;
                DateTime fecha 				= Convert.ToDateTime(txt_fecha.Text);
                // clrGuia.SelectedDate;
                string observaciones 		= tbxobservaciones.Text;
                int estado 					= Convert.ToInt16(DropEstado.SelectedValue);
                string usuresponsable 		= tbxUsrResponsable.Text;
                int TipoEquipo 				= Convert.ToInt16(DropTipoEquipo.SelectedValue);
                try
                {
                    //DataTable Nguia = new DataTable();
                    //Nguia = PreparaAcceso.ObtenerNumGuia(cadenaConexion);
                    //string nroGuia = Nguia.Rows[0][0].ToString();
                    string nroGuia = txtNro.Text;

                    if (PreparaAcceso.BuscaGuiaPorNumero(Convert.ToDecimal(nroGuia), cadenaConexion) == false)
                    {
                        PreparaAcceso.InsertarGuia(Int32.Parse(nroGuia), rutcliente, nomusuario, CueServidor, passServidor, numserie, sisasignado, sucursal, nomequipo, descripcion, dirrecionip, sisoperativo, antivirus, office, idteamviewer, passteamviewer,fecha, observaciones, estado, usuresponsable, TipoEquipo, cadenaConexion);
                        Response.Write("<script >alert('Guia Nro " + nroGuia + " ingresada Correctamente');location.href = 'Guias.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script >alert('Número de Guía ya Existe');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script >alert('Error guia no ingresada');</script>");
                }
            }
            else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado');</script>");

            }
            else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue == "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Sucursal');</script>");
            }
            else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue == "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Cliente');</script>");
            }
            else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Tipo de Equipo');</script>");
            }
            else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue == "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado y Sucursal');</script>");
            }
            else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado y Tipo de Equipo');</script>");
            }
            else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue == "-1" & DropRutCliente.SelectedValue == "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Sucursal y Cliente');</script>");
            }
            else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue == "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Sucursal y Tipo de Equipo');</script>");
            }
            else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue == "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado y Cliente');</script>");
            }
            else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue == "-1" & DropTipoEquipo.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Cliente y Tipo de Equipo');</script>");
            }
            else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue == "-1" & DropRutCliente.SelectedValue == "-1" & DropTipoEquipo.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado , Sucursal y Cliente');</script>");
            }
            else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue == "-1" & DropRutCliente.SelectedValue != "-1" & DropTipoEquipo.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado, Sucursal y Tipo de Equipo');</script>");
            }
            else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue != "-1" & DropRutCliente.SelectedValue == "-1" & DropTipoEquipo.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado, Cliente y Tipo Equipo');</script>");
            }
            else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue == "-1" & DropRutCliente.SelectedValue == "-1" & DropTipoEquipo.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Sucursal, Cliente y Tipo de Equipo');</script>");
            }
            else
            {
                Response.Write("<script >alert('Verifique Seleccion de Sucursal, Estado, Cliente y Tipo de Equipo');</script>");
            }
            
        }

        protected void Buttonvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Guias.aspx");
        }


       

    }
}