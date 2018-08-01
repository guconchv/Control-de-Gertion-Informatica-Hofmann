using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using System.Collections;
using System.IO.Compression;  

namespace ControlArriendos
{

  public partial class Devoluciones : System.Web.UI.Page
  {
      public const string SELECTED_CUSTOMERS_INDEX = "SelectedCustomersIndex";
      string cadenaConexion = MasterPage.CadenaConexion;
      int NroGuia;
      
     
      protected void Page_Load(object sender, EventArgs e)
      {
          if (!IsPostBack)
          {
              DataTable cliente = new DataTable();

              cliente = PreparaAcceso.BuscarRutNomClientes(cadenaConexion);

              DropCliente.DataSource = cliente;
              DropCliente.DataValueField = "cli_rut_cli";
              DropCliente.DataTextField = "cli_nom_cli";
              DropCliente.DataBind();
              DropCliente.SelectedValue = "-1";

              LlenaGrillaGuias();
              pMsjGuia.Visible = false;
          }
      }

      public void LlenaGrillaGuias()
      {
          int Cliente = Convert.ToInt32(DropCliente.SelectedValue);

          GVGuias.DataSource = PreparaAcceso.ObtenerGuiasDevueltas(Cliente,cadenaConexion);
          GVGuias.DataBind();

         // RePopulateCheckBoxes();
          if (GVGuias.Rows.Count > 0)
          {
              Seleccione.Visible = true;
              btn_grabar.Visible = true;
          }
          else
          {
              Seleccione.Visible = false;
              btn_grabar.Visible = false;
          }

      }

      //paginación de la grilla
     protected void GVGuias_PageIndexChanging(object sender, GridViewPageEventArgs e)
      {
          foreach (GridViewRow row in GVGuias.Rows)
          {
              var chkBox = row.FindControl("chequeaDevolver") as CheckBox;

              IDataItemContainer container = (IDataItemContainer)chkBox.NamingContainer;

              if (chkBox.Checked)
              {
                  PersistRowIndex(container.DataItemIndex);
              }
              else
              {
                  RemoveRowIndex(container.DataItemIndex);
              }
          }
          
              this.GVGuias.PageIndex = e.NewPageIndex;
              LlenaGrillaGuias();          
      }
     

      public void Chequear_Seleccion()
      {
          foreach (GridViewRow row in this.GVGuias.Rows)
          {
              CheckBox ch = (CheckBox)row.FindControl("chequeaDevolver");

              if (ch.Checked == false) 
              {
                  ch.Checked = true;
              }
              else if (ch.Checked == true)
              {
                  ch.Checked = true;
              }
          }
       
      }

      public void Deschequear_Seleccion()
      {
          foreach (GridViewRow row in this.GVGuias.Rows)
          {
              CheckBox ch = (CheckBox)row.FindControl("chequeaDevolver");

              if (ch.Checked == true) 
              {
                  ch.Checked = false;             
              }
              else if (ch.Checked == false)
              {
                  ch.Checked = false;               
              }
          }
      }

      protected void btn_grabar_Click(object sender, EventArgs e)
      {
          Cancelar_Devolución();
          Grabar_Devolucion();
      }

      protected void btnQuitar_Click(object sender, EventArgs e)
      {
          Deschequear_Seleccion();
      }

      protected void Seleccione_Click(object sender, EventArgs e)
      {
          Chequear_Seleccion();
          btnQuitar.Visible = true;
      }

      protected void btnBuscar_Click(object sender, EventArgs e)
      {
          pMsjGuia.Visible = false;

          if (DropCliente.SelectedValue == "-1")
          {
              pMsjGuia.Visible = true;
          }
          else
          {
             LlenaGrillaGuias();
          }
      }

      public void Grabar_Devolucion()
      {
          int guia = 0;

          foreach (GridViewRow row in this.GVGuias.Rows)
              {
                  // se declara una variable de tipo checbox
                  CheckBox ck = (CheckBox)row.FindControl("chequeaDevolver");

                  if (ck.Checked) // si esta chequeado 
                  {
                      //Decimal Nroguia = row.Cells[1].Text;
                      guia = guia + 1;
                      NroGuia = Convert.ToInt16(row.Cells[1].Text);
                      PreparaAcceso.ModificarEstadoGuia(NroGuia, cadenaConexion);
                  }
              }
          foreach (GridViewRow row in this.GVGuias.Rows)
          {
              if (((CheckBox)row.FindControl("chequeaDevolver")).Checked)
              {
                  Response.Write("<script >alert('" + guia + " guia(s) han sido devueltos exitosamente')</script>");
                  break;
              }
          }
          RefreshData();
      }
      public void Cancelar_Devolución()
      {
          int cont = 0;

          foreach (GridViewRow row in this.GVGuias.Rows)
          {
              // se declara una variable de tipo checbox
              CheckBox ck = (CheckBox)row.FindControl("chequeaDevolver");

              if (ck.Checked == false) // si esta chequeado 
              {
                  cont = cont + 1;
              }
          }
          if (cont >= GVGuias.Rows.Count)
          {
              Response.Write("<script >alert('Debe ingresar por lo menos una guía')</script>");
          }
      }
    

      public void RefreshData()
      {
          try
          {
              //Con el parametro de codigo consulta en la BD y devuelve una lista de campos los cuales los muestra en la Gridview
              int Cliente = Convert.ToInt32(DropCliente.SelectedValue);
              GVGuias.DataSource = PreparaAcceso.ObtenerGuiasDevueltas(Cliente, cadenaConexion);
              GVGuias.DataBind();
          }
          catch (Exception exp)
          {
              Response.Write(exp.Message);
          }
      }

      //Para volver a llamar los checkbox en la gridview paginada
      private void RePopulateCheckBoxes()
      {
          foreach (GridViewRow row in GVGuias.Rows)
          {
              var chkBox = row.FindControl("chequeaDevolver") as CheckBox;

              IDataItemContainer container = (IDataItemContainer)chkBox.NamingContainer;

              if (SelectedCustomersIndex != null)
              {
                  if (SelectedCustomersIndex.Exists(i => i == container.DataItemIndex))
                  {
                      chkBox.Checked = true;
                  }
              }
          }
      }
      //Almacena los checkbox
      private List<Int32> SelectedCustomersIndex
      {
          get
          {
              if (ViewState[SELECTED_CUSTOMERS_INDEX] == null)
              {
                  ViewState[SELECTED_CUSTOMERS_INDEX] = new List<Int32>();
              }
              return (List<Int32>)ViewState[SELECTED_CUSTOMERS_INDEX];
          }
      }
      //Agregar y quitar los checkbox
      private void RemoveRowIndex(int index)
      {
          SelectedCustomersIndex.Remove(index);
      }

      private void PersistRowIndex(int index)
      {
          if (!SelectedCustomersIndex.Exists(i => i == index))
          {
              SelectedCustomersIndex.Add(index);
          }
      }
      
  }
}