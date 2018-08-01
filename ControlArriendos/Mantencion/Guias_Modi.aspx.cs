using Negocios;
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
    public partial class Guias_Modi : System.Web.UI.Page
    {
        string cadenaConexion = MasterPage.CadenaConexion;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
              // txt_fecha.Text = DateTime.Today.ToString("yyyy/MM/dd");
                TextBox1.Attributes.Add("readonly", "readonly");
                ActivarDesactivarControles(1);
                DataTable sucursal = new DataTable();

                sucursal = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodSucursales, cadenaConexion);

                DropSucursal.DataSource = sucursal;
                DropSucursal.DataValueField = "PAR_COD_PAR";
                DropSucursal.DataTextField = "PAR_DES_PAR";
                DropSucursal.DataBind();


                DataTable estado = new DataTable();

                estado = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodEstadosGuias, cadenaConexion);

                DropEstado.DataSource = estado;
                DropEstado.DataValueField = "PAR_COD_PAR";
                DropEstado.DataTextField = "PAR_DES_PAR";
                DropEstado.DataBind();

                DataTable TipoEquipo = new DataTable();

                TipoEquipo = PreparaAcceso.BuscaParametrosPorTabla(Codigo_TablasPadres.CodTipoEquipo, cadenaConexion);

                DropTipoEquipo.DataSource = TipoEquipo;
                DropTipoEquipo.DataValueField = "PAR_COD_PAR";
                DropTipoEquipo.DataTextField = "PAR_DES_PAR";
                DropTipoEquipo.DataBind();

                LLenaDetalleGuia();

            }
            

           
        }
         public void LLenaDetalleGuia()
         {
             DataTable lector = new DataTable();
             lector = PreparaAcceso.BuscaGuiaPorNro(Convert.ToInt16(Request.QueryString["ID"]), cadenaConexion);
             
             lbltitulo.Text += lector.Rows[0][0].ToString();
             //  ******************  Llenado TextBox   *************************
             tbxRutCliente.Text = lector.Rows[0][1].ToString();
             tbxNomUsuario.Text = lector.Rows[0][2].ToString();
             tbxCueServidor.Text = lector.Rows[0][3].ToString();
             tbxPassServidor.Text = lector.Rows[0][4].ToString();
             tbxNumSerie.Text = lector.Rows[0][5].ToString();
             tbxSisAsignados.Text = lector.Rows[0][6].ToString();
             tbxNomEquipo.Text = lector.Rows[0][9].ToString();
             tbxDescripcion.Text = lector.Rows[0][10].ToString();
             tbxDirIp.Text = lector.Rows[0][11].ToString();
             tbxSisOperativo.Text = lector.Rows[0][12].ToString();
             tbxAntivirus.Text = lector.Rows[0][13].ToString();
             tbxOffice.Text = lector.Rows[0][14].ToString();
             tbxIdTeamviewer.Text = lector.Rows[0][15].ToString();
             tbxPassTeamviewer.Text = lector.Rows[0][16].ToString();
             //tbxFecha.Text = String.Format("{0:dd-MM-yyyy}", lector.Rows[0][16].ToString());
             TextBox1.Text = Convert.ToDateTime(lector.Rows[0][17]).ToString("dd/MM/yyyy");
            // divTitle.Controls.Clear();
             //divTitle.InnerHtml = " <input type='text' class='input_Text' id='datepicker'  name='Title'  value='" + Convert.ToDateTime(lector.Rows[0][17]).ToString("dd/MM/yyyy") + "' style='width: 239px' runat='server' /> ";
       
            // txt_fecha.Text = lector.Rows[0][17].ToString();
             
             //clrGuia.SelectedDate = Convert.ToDateTime(lector.Rows[0][17]);
             //clrGuia.VisibleDate = Convert.ToDateTime(lector.Rows[0][17]);
             tbxObservaciones.Text = lector.Rows[0][18].ToString();
             tbxUsuResponsable.Text = lector.Rows[0][20].ToString();

             //  ******************  Llenado DropDownList   ********************
             //*******************************Iniciacion de combos
             DropSucursal.SelectedValue = lector.Rows[0][7].ToString();
             DropTipoEquipo.SelectedValue =lector.Rows[0][8].ToString();
             DropEstado.SelectedValue= lector.Rows[0][19].ToString();
          
         }

       

         protected void imgEliminar_Click(object sender, ImageClickEventArgs e)
         {
             try
             {
                 PreparaAcceso.EliminarGuiaPorNro(Int32.Parse(Request.QueryString["ID"]), cadenaConexion);
                 Response.Write("<script >alert('Guia Eliminada Correctamente');location.href = 'Guias.aspx';</script>");

             }
             catch (Exception)
             {
                 
                 Response.Write("<script >alert('Error guia no fue Eliminada');</script>");
             }
         }

         protected void btnModificar_Click(object sender, EventArgs e)
         {
             ActivarDesactivarControles(2);
            
         }

         protected void btnCancelar_Click(object sender, EventArgs e)
         {
             ActivarDesactivarControles(1);
             

         }

         protected void btnGuasrdarC_Click(object sender, EventArgs e)
         {

             if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue != "-1" & DropTipoEquipo.SelectedValue != "-1" )
             {
                 string NombreUsuario = Session["NomUsuario"].ToString();
                

                 string nroGuia = Request.QueryString["ID"];
                 //int rutcliente = Int32.Parse(tbxRutCliente.Text);
                 string nomusuario = tbxNomUsuario.Text;
                 string CueServidor = tbxCueServidor.Text;
                 string passServidor = tbxPassServidor.Text;
                 string numserie = tbxNumSerie.Text;
                 string sisasignado = tbxSisAsignados.Text;
                 int sucursal = Convert.ToInt16(DropSucursal.SelectedValue);
                 string nomequipo = tbxNomEquipo.Text;
                 string descripcion = tbxDescripcion.Text;
                 string dirrecionip = tbxDirIp.Text;
                 string sisoperativo = tbxSisOperativo.Text;
                 string antivirus = tbxAntivirus.Text;
                 string office = tbxOffice.Text;
                 string idteamviewer = tbxIdTeamviewer.Text;
                 string passteamviewer = tbxPassTeamviewer.Text;
                 DateTime fecha = Convert.ToDateTime(TextBox1.Text);
                 
                 //DateTime fecha = clrGuia.SelectedDate; 
                 string observaciones = tbxObservaciones.Text;
                 int estado = Convert.ToInt16(DropEstado.SelectedValue);
                 string usuresponsable = NombreUsuario;
             
                 int TipoEquipo = Convert.ToInt16(DropTipoEquipo.SelectedValue);

                 try
                 {
                     PreparaAcceso.ActualizarGuia(Int32.Parse(nroGuia), nomusuario, CueServidor, passServidor, numserie, sisasignado, sucursal, nomequipo, descripcion, dirrecionip, sisoperativo, antivirus, office, idteamviewer, passteamviewer, Convert.ToDateTime(fecha), observaciones, estado, usuresponsable, TipoEquipo,cadenaConexion);
                     Response.Write("<script >alert('Guia Modificada Correctamente');location.href = 'Guias.aspx';</script>");
                     //Response.Redirect("Guias.aspx");
                 }
                 catch (Exception)
                 {
                     Response.Write("<script >alert('Error guia no Modificada');</script>");
                 }
             }
             else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue != "-1" & DropTipoEquipo.SelectedValue != "-1")
             {
                 Response.Write("<script >alert('Verifique Seleccion de Estado');</script>");
             }
             else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue == "-1" & DropTipoEquipo.SelectedValue != "-1")
             {
                 Response.Write("<script >alert('Verifique Seleccion de Sucursal');</script>");
             }
             else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue == "-1" & DropTipoEquipo.SelectedValue != "-1")
             {
                 Response.Write("<script >alert('Verifique Seleccion de Estado y Sucursal');</script>");
             }
             else if (DropEstado.SelectedValue == "-1" & DropSucursal.SelectedValue != "-1" & DropTipoEquipo.SelectedValue == "-1")
             {
                 Response.Write("<script >alert('Verifique Seleccion de Estado y Tipo de Equipo');</script>");
             }
             else if (DropEstado.SelectedValue != "-1" & DropSucursal.SelectedValue == "-1" & DropTipoEquipo.SelectedValue == "-1")
             {
                 Response.Write("<script >alert('Verifique Seleccion de Sucursal y Tipo de Equipo');</script>");
             }
             else
             {
                 Response.Write("<script >alert('Verifique Seleccion de Sucursal, Estado y Tipo de Equipo');</script>");
             }
         }
         private void ActivarDesactivarControles(int accion)
         {
             if (accion == 1)
             {
                 tbxRutCliente.Enabled = false;
                 tbxNomUsuario.Enabled = false;
                 tbxCueServidor.Enabled = false;
                 tbxPassServidor.Enabled = false;
                 tbxNumSerie.Enabled = false;
                 tbxSisAsignados.Enabled = false;
                 tbxNomEquipo.Enabled = false;
                 tbxDescripcion.Enabled = false;
                 tbxDirIp.Enabled = false;
                 tbxSisOperativo.Enabled = false;
                 tbxAntivirus.Enabled = false;
                 tbxOffice.Enabled = false;
                 tbxIdTeamviewer.Enabled = false;
                 tbxPassTeamviewer.Enabled = false;
                 //tbxFecha.Text = String.Format("{0:dd-MM-yyyy}", lector.Rows[0][16].ToString());
              
                 TextBox1.Enabled = false;
               
        
                 //clrGuia.Enabled = false; 
                 // clrGuia.VisibleDate = Convert.ToDateTime(lector.Rows[0][16]);
                 tbxObservaciones.Enabled = false;
                 tbxUsuResponsable.Enabled = false;
                
                 //  ******************  Llenado DropDownList   ********************
                 //*******************************Iniciacion de combos
                 DropSucursal.Enabled = false;
                 DropEstado.Enabled = false;
                 DropTipoEquipo.Enabled = false;

                 btnVolver.Visible = true;
                 btnModificar.Visible = true;

                 LbtnCancelar.Visible = false;
                 btnGuasrdarC.Visible = false;
             }
             else if (accion == 2)
             {
                 tbxNomUsuario.Enabled = true;
                 tbxCueServidor.Enabled = true;
                 tbxPassServidor.Enabled = true;
                 tbxNumSerie.Enabled = true;
                 tbxSisAsignados.Enabled = true;
                 tbxNomEquipo.Enabled = true;
                 tbxDescripcion.Enabled = true;
                 tbxDirIp.Enabled = true;
                 tbxSisOperativo.Enabled = true;
                 tbxAntivirus.Enabled = true;
                 tbxOffice.Enabled = true;
                 tbxIdTeamviewer.Enabled = true;
                 tbxPassTeamviewer.Enabled = true;
                 //tbxFecha.Text = String.Format("{0:dd-MM-yyyy}", lector.Rows[0][16].ToString());
                 //Calendario.Visible = true;
                 TextBox1.Enabled = true;
                
            
                 //clrGuia.Enabled = true; 
                 //clrGuia.VisibleDate = Convert.ToDateTime(lector.Rows[0][16]);
                 tbxObservaciones.Enabled = true;
                 //tbxUsuResponsable.Enabled = true;

                 //  ******************  Llenado DropDownList   ********************
                 //*******************************Iniciacion de combos
                 DropSucursal.Enabled = true;
                 DropEstado.Enabled = true;
                 DropTipoEquipo.Enabled = true;

                 btnVolver.Visible = false;
                 btnModificar.Visible = false;

                 LbtnCancelar.Visible = true;
                 btnGuasrdarC.Visible = true;
             }
            
         }

         protected void clrGuia_SelectionChanged(object sender, EventArgs e)
         {
             ActivarDesactivarControles(2);
         }

     
    }
    
}