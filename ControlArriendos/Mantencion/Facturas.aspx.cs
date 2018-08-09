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
    public partial class Facturas : System.Web.UI.Page
    {
        string CadenaConexion = MasterPage.CadenaConexion;
        string rut;
        string nombre;
        int num_factura;
        DateTime fecha_factura;
        int contacto;
        string mail;
        DateTime fecha_regist;
        string orden_compra;
        decimal total;
        string descrip;     

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AgregarFacturas(object sender, EventArgs e)
        {
            rut = rut_empresa.Text;
            nombre = nombre_empresa.Text;
            num_factura = Convert.ToInt32(nro_documento.Text);
            fecha_factura = Convert.ToDateTime(txt_fecha.Text);
            contacto = Convert.ToInt32(telefono.Text);
            mail = correo.Text;
            fecha_regist = Convert.ToDateTime(fechaingreso.Text);
            orden_compra = OC.Text;
            total = Convert.ToDecimal(valor.Text);
            descrip = descripcion.Text;

            DataTable NuevaFactura = new DataTable();

            NuevaFactura = PreparaAcceso.GuardarFacturas(rut, nombre, num_factura, fecha_factura, contacto, mail, fecha_regist, orden_compra, total, descrip, CadenaConexion);
            Response.Write("<script >alert('Datos Guardados Correctamente');location.href = 'Facturas.aspx';</script>");
        }

    }
}