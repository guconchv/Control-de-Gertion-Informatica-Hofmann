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
        string rut;
        string nombre;
        string telef;
        string depar;
        string correo;
        DateTime fecha;
        string tip;
        string tecnico;
        int licen_off;
        int licen_win;
        string id_equipo;
        string eq_hardware;
        string eq_marca;
        string eq_modelo;
        string eq_serie;
        string comentarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public void GuardarRegistroEquipos()
        {
            DataTable registro = new DataTable();
           registro = PreparaAcceso.RegistroEquipo(rut, nombre, telef, depar, correo, fecha, tip, tecnico, licen_off, licen_win,
            id_equipo, eq_hardware, eq_marca, eq_modelo, eq_serie, comentarios, CadenaConexion);
        }
        protected void GuardarIngreso(object sender, EventArgs e)
        {
            GuardarRegistroEquipos();
        }
    }
}