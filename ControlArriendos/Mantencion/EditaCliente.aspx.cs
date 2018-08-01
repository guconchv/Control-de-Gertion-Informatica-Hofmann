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
    public partial class EditaCliente : System.Web.UI.Page
    {
        string CadenaConexion = MasterPage.CadenaConexion;
        string Rut;
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
                LLenaCombos();
                LLenaInfoCliente();
            }
        }
        public void LLenaCombos()
        {
            txt_fecha.Attributes.Add("readonly", "readonly");

            DataTable Comuna1 = new DataTable();

            Comuna1 = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodComunas, CadenaConexion);
            DropComuna.DataSource = Comuna1;
            DropComuna.DataValueField = "par_cod_par";
            DropComuna.DataTextField = "par_des_par";
            DropComuna.DataBind();

            DataTable Ciudad1 = new DataTable();

            Ciudad1 = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodCiudades, CadenaConexion);
            DropCiudad.DataSource = Ciudad1;
            DropCiudad.DataValueField = "par_cod_par";
            DropCiudad.DataTextField = "par_des_par";
            DropCiudad.DataBind();

            DataTable Estado1 = new DataTable();

            Estado1 = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.codEstados, CadenaConexion);

            DropEstado.DataSource = Estado1;
            DropEstado.DataValueField = "par_cod_par";
            DropEstado.DataTextField = "par_des_par";
            DropEstado.DataBind();
        }

        public void LLenaInfoCliente()
        {
           
            DataTable lector = new DataTable();
            //lector = AccesoLogica.BuscarEmpleadoT(id, CadenaConexion);
            lector = PreparaAcceso.BuscarClientePorId(Convert.ToDecimal(Request.QueryString["ID"]), CadenaConexion);


            //  ******************  Llenado TextBox   *************************
            this.txtRut.Text = lector.Rows[0][0].ToString();
            txtRut.Enabled = false;
            this.txtDigito.Text = lector.Rows[0][1].ToString();
            txtDigito.Enabled = false;
            this.txtNombre.Text = lector.Rows[0][2].ToString();
            this.txtDireccion.Text = lector.Rows[0][3].ToString();
            this.txtFijo.Text = lector.Rows[0][6].ToString();
            this.txtMovil.Text = lector.Rows[0][7].ToString();
            this.txtCorreo.Text = lector.Rows[0][8].ToString();
            //Llenado de fechas
            this.txt_fecha.Text = Convert.ToDateTime(lector.Rows[0][9]).ToString("dd/MM/yyyy");
            //this.txt_fecha.Text = lector.Rows[0][9].ToString(); 
           // this.Calendar1.SelectedDate = Convert.ToDateTime(lector.Rows[0][9]);
            //*******************************Iniciacion de combos
            DropComuna.SelectedValue = lector.Rows[0][4].ToString();
            DropCiudad.SelectedValue = lector.Rows[0][5].ToString();
            DropEstado.SelectedValue = lector.Rows[0][10].ToString();

        }

        protected void ModificarCliente_Click(object sender, EventArgs e)
        {
            if (DropComuna.SelectedValue != "-1" & DropCiudad.SelectedValue != "-1" & DropEstado.SelectedValue != "-1")
            {
                Rut = Request.QueryString["ID"];
                Nombre = txtNombre.Text;
                Direccion = txtDireccion.Text;
                TelFijo = txtFijo.Text;
                TelMovil = txtMovil.Text;
                Correo = txtCorreo.Text;
                Fecha = Convert.ToDateTime(txt_fecha.Text);
                //Fecha = Calendar1.SelectedDate;
                Usuario = Session["NomUsuario"].ToString();

                Comuna = DropComuna.SelectedValue;
                Ciudad = DropCiudad.SelectedValue;
                Estado = DropEstado.SelectedValue;

                string[] array = new string[] { Convert.ToString(Fecha), Usuario};

                if (PreparaAcceso.funsionValFormVacios(array))
                {
                    if (PreparaAcceso.validarEmail(Correo) == true)
                    {
                        PreparaAcceso.ActualizaCliente(Convert.ToDecimal(Rut), Nombre, Direccion, Convert.ToInt32(Comuna), Convert.ToInt32(Ciudad), TelFijo, TelMovil, Correo, Fecha, Convert.ToInt32(Estado), Usuario, CadenaConexion);
                        Response.Redirect("~/Mantencion/Clientes.aspx");
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

  

    }
}