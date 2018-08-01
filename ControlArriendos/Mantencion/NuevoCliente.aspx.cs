using Negocios;
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
    public partial class NuevoCliente : System.Web.UI.Page
    {
        string CadenaConexion = MasterPage.CadenaConexion;
        string Rut;
        string Digito;
        string Nombre;
        string Direccion;
        string Comuna;
        string Ciudad;
        string TelFijo;
        string TelMovil;
        string Correo;
        DateTime Fecha;
        string Estado;
        string Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DateTime localDate = DateTime.Now;
               // Calendar1.SelectedDate = localDate;
                txt_fecha.Attributes.Add("readonly", "readonly");
                txt_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataTable Comuna1 = new DataTable();

                Comuna1 = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodComunas, CadenaConexion);
                DropComuna.DataSource = Comuna1;
                DropComuna.DataValueField = "par_cod_par";
                DropComuna.DataTextField = "par_des_par";
                DropComuna.DataBind();
                DropComuna.SelectedValue = "-1";

                DataTable Ciudad1 = new DataTable();

                Ciudad1 = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodCiudades, CadenaConexion);
                DropCiudad.DataSource = Ciudad1;
                DropCiudad.DataValueField = "par_cod_par";
                DropCiudad.DataTextField = "par_des_par";
                DropCiudad.DataBind();
                DropCiudad.SelectedValue = "-1";

                DataTable Estado1 = new DataTable();

                Estado1 = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.codEstados, CadenaConexion);

                DropEstado.DataSource = Estado1;
                DropEstado.DataValueField = "par_cod_par";
                DropEstado.DataTextField = "par_des_par";
                DropEstado.DataBind();
                DropEstado.SelectedValue = "-1"; 
            }
        }



        protected void AgregarCliente_Click(object sender, EventArgs e)
        {
            if (DropComuna.SelectedValue != "-1" & DropCiudad.SelectedValue != "-1" & DropEstado.SelectedValue != "-1")
            {
                Rut = txtRut.Text;
                Digito = PreparaAcceso.Dv(Rut);
                Nombre = txtNombre.Text;
                Direccion = txtDireccion.Text;
                TelFijo = txtFijo.Text;
                TelMovil = txtMovil.Text;
                Correo = txtCorreo.Text;
               // Fecha = Calendar1.SelectedDate;
                Fecha = Convert.ToDateTime(txt_fecha.Text);
                Usuario = Session["NomUsuario"].ToString();
                Comuna = DropComuna.SelectedValue;
                Ciudad = DropCiudad.SelectedValue;
                Estado = DropEstado.SelectedValue;

                string[] array = new string[] { Digito,Convert.ToString(Fecha),Usuario };

                if (PreparaAcceso.funsionValFormVacios(array))
                {

                    if (PreparaAcceso.validarEmail(Correo) == true)
                    {
                        PreparaAcceso.AgregaCliente(Convert.ToDecimal(Rut), Digito, Nombre, Direccion, Convert.ToInt32(Comuna), Convert.ToInt32(Ciudad), TelFijo, TelMovil, Correo, Fecha, Convert.ToInt32(Estado), Usuario, CadenaConexion);
                        Response.Write("<script >alert('Cliente ingresado Correctamente');location.href = 'Clientes.aspx';</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<SCRIPT LANGUAGE='javascript'> alert('complete el campo Correo Electronico con un email valido!');</SCRIPT>");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<SCRIPT LANGUAGE='javascript'> alert('Complete Los Campos Que Estan vacios!');</SCRIPT>");
                }
            }
            else if (DropComuna.SelectedValue == "-1" & DropCiudad.SelectedValue != "-1" & DropEstado.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Comuna');</script>");

            }
            else if (DropComuna.SelectedValue != "-1" & DropCiudad.SelectedValue == "-1" & DropEstado.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Ciudad');</script>");
            }
            else if (DropComuna.SelectedValue != "-1" & DropCiudad.SelectedValue != "-1" & DropEstado.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Estado');</script>");
            }
            else if (DropComuna.SelectedValue == "-1" & DropCiudad.SelectedValue == "-1" & DropEstado.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Comuna y Ciudad');</script>");
            }
            else if (DropComuna.SelectedValue != "-1" & DropCiudad.SelectedValue == "-1" & DropEstado.SelectedValue == "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Ciudad y Estado');</script>");
            }
            else if (DropComuna.SelectedValue == "-1" & DropCiudad.SelectedValue == "-1" & DropEstado.SelectedValue != "-1")
            {
                Response.Write("<script >alert('Verifique Seleccion de Comuna y Estado');</script>");
            }
            else
            {
                Response.Write("<script >alert('Verifique Seleccion de Ciudad, Comuna y Estado ');</script>");
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}