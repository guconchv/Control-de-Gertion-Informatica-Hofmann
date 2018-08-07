using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlArriendos.Mantencion
{
    public partial class Equipos : System.Web.UI.Page
    {
        string CadenaConexion = MasterPage.CadenaConexion;
        int codigo;
        string rut;
        string nombre;
        int telef;
        int movil;
        string departamento;
        string correo;
        DateTime fecha;
        string tecnico;
        string tipo;
        string office;
        string windows;
        int factura_rela;
        string hardware;
        string marca;
        string modelo;
        string serie;
        string comentario;
        
        protected void GuardarIngreso(object sender, EventArgs e)
        {
                codigo = Convert.ToInt32(txtcodigo.Text);
                rut = txtrut.Text;
                nombre = txtNombre.Text;
                telef = Convert.ToInt32(txtanexo.Text);
                movil = Convert.ToInt32(txtcelular.Text);
                departamento = txtdepartamento.Text;
                correo = txtcorreo.Text;
                fecha = Convert.ToDateTime(txt_fecha.Text);
                tipo = txttipo.Text;
                tecnico = txttecnico.Text;
                office = txtOffice.Text;
                windows = txtwindows.Text;
                factura_rela = Convert.ToInt32(txtfactura.Text);
                hardware = txtHardware.Text;
                marca = txtMarca.Text;
                modelo = txtModelo.Text;
                serie = txtSerie.Text;
                comentario = txtComentario.Text;

                DataTable InsertarEquipo = new DataTable();

                InsertarEquipo = PreparaAcceso.CompletarRegistro(codigo, rut, nombre, telef, movil, departamento, correo, fecha, tipo,
                tecnico, office, windows,factura_rela, hardware, marca, modelo, serie, comentario, CadenaConexion);
                Response.Write("<script >alert('Datos Guardados Correctamente');location.href = 'Equipos.aspx';</script>");
        }
    }
}