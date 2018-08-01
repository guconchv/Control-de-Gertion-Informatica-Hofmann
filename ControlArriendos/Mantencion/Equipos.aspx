<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="ControlArriendos.Mantencion.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script>
         $(document).ready(function () {
             $('#<%=txt_fecha.ClientID%>').datepicker({
                 dateFormat: 'dd-mm-yy',
                 maxDate: "+0m +0d",
                 changeMonth: true,
                 changeYear: true
             }).val();
         });
      </script>
<head >
    <title></title>
    	
</head>
<body>

    <div  align="center" style="width: 1700px; height: 70px;">
       <br />
        <br />
     <center><h2 class="Titulos">REGISTRO DE EQUIPOS</h2></center>
       <br />
     </div>
     <br />
     <br />
    <asp:Panel ID="PanelCabecera" runat="server" Width="1697px" Height="123px" style="margin-bottom: 0px">
        <div  align="center" style="width: 1700px; margin-bottom: 53px;">
        <asp:Label ID="Label2" runat="server" CssClass="Texto" Text="CAMPOS OBLIGATORIOS" Font-Size="10pt"></asp:Label>
            <table  class="Tabla_Estructura">
                 <tr align="center">
       <td class="auto-style14" >
           <asp:Label ID="Label5" runat="server" CssClass="Texto" Text="RUT  " Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" >
           <asp:TextBox ID="rut" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label6" runat="server" CssClass="Texto" Text="NOMBRE" Font-Size="10pt"></asp:Label>
        </td>
        <td class="auto-style12" >
           <asp:TextBox ID="nombre" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <caption>
            &nbsp;
        </caption>
                <tr align="center">
       <td class="auto-style14" >
           <asp:Label ID="Label1" runat="server" CssClass="Texto" Text="ANEXO  :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" >
           <asp:TextBox ID="txtanexo" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label3" runat="server" CssClass="Texto" Text="DEPARTAMENTO :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29">         
          <asp:DropDownList 
              ID="DropDepartamento" TextDefault="Seleccione" runat="server" CssClass="Texto" Height="25px" Width="140px">
          </asp:DropDownList>                            
        </td>
    </tr>
       <tr align="center">
       <td class="auto-style14" >
           <asp:Label ID="Label7" runat="server" CssClass="Texto" Text="CELULAR  :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" >
           <asp:TextBox ID="txtcelular" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style14" >
           <asp:Label ID="Label10" runat="server" CssClass="Texto" Text="CORREO  :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" >
           <asp:TextBox ID="txtcorreo" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
       <tr align="center">
           <caption>
               &lt;<td class="auto-style20" style="width: 148px">
                   <asp:Label ID="Label80" runat="server" CssClass="Texto" Font-Size="10pt" Text="FECHA INGRESO :"></asp:Label>
               </td>
               <td class="auto-style30">
                   <asp:TextBox ID="txt_fecha" runat="server" CssClass="textbox" Enabled="True" Height="16px" style=" text-align: center" Width="130px"></asp:TextBox>
               </td>
               <td class="auto-style14">
                   <asp:Label ID="Label15" runat="server" CssClass="Texto" Font-Size="10pt" Text="TIPO  :"></asp:Label>
               </td>
               <td class="auto-style29">
                   <asp:DropDownList ID="DropDownListTipo" runat="server" CssClass="Texto" Height="25px" TextDefault="Seleccione" Width="140px">
                   </asp:DropDownList>
               </td>
           </caption>
        </tr>
       <tr align="center">
        <td class="auto-style14" >
            <asp:Label ID="Label16" runat="server" CssClass="Texto" Text="INGRESADO POR  :" Font-Size="10pt"></asp:Label>
       </td>
       <td class="auto-style29">         
          <asp:DropDownList 
              ID="DropTecnico" TextDefault="Seleccione" runat="server" CssClass="Texto" Height="25px" Width="140px">
          </asp:DropDownList>                            
        </td>
        <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label17" runat="server" CssClass="Texto" Text="LICENCIA OFFICE :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29">         
          <asp:DropDownList 
              ID="DropDownListWin" TextDefault="Seleccione" runat="server" CssClass="Texto" Height="25px" Width="140px">
          </asp:DropDownList>                            
         <tr align ="center">
            <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label18" runat="server" CssClass="Texto" Text="LICENCIA WINDOWS :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29">         
          <asp:DropDownList 
              ID="DropDownListOffice" TextDefault="Seleccione" runat="server" CssClass="Texto" Height="25px" Width="140px">
          </asp:DropDownList>
        </tr> 
           </tr>
         </center>
         </table>
            <div align="center" style="width: 1700px; height: 520px;">
                <table id="tabla" style="width: 757px; margin-top: 17px; margin-left: 0px;">
                    <tr align="center">
                        <td class="auto-style12">
                            <asp:Label ID="Label4" runat="server" CssClass="Texto" Font-Size="10pt" Text="Codigo"></asp:Label>
                        </td>
                       <td class="auto-style20">
                            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="30" name="txtequipo"></asp:TextBox>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="Label8" runat="server" CssClass="Texto" Font-Size="10pt" Text="Hardware"></asp:Label>
                        </td>
                        <td class="auto-style29">
                            <asp:TextBox ID="txtHardware" runat="server" MaxLength="30" name="txthardware" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td class="auto-style20" style="width: 90px">
                            <asp:Label ID="Label9" runat="server" CssClass="Texto" Font-Size="10pt" Text="Marca"></asp:Label>
                        </td>
                        <td class="auto-style30">
                            <asp:TextBox ID="txtMarca" runat="server" MaxLength="30" name="txtmarca"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td class="auto-style29">
                            <asp:Label ID="Label12" runat="server" CssClass="Texto" Font-Size="10pt" Text="Modelo"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:TextBox ID="txtModelo" runat="server" MaxLength="30" name="txtmodelo"></asp:TextBox>
                        </td>
                        <td class="auto-style29">
                            <asp:Label ID="Label13" runat="server" CssClass="Texto" Font-Size="10pt" Text="Serie"></asp:Label>
                        </td>
                        <td class="auto-style32">
                            <asp:TextBox ID="txtSerie" runat="server" MaxLength="30" name="txtsodelo"> </asp:TextBox>
                        </td>
                        <td class="auto-style29" style="width: 90px">
                            <asp:Label ID="Label14" runat="server" CssClass="Texto" Font-Size="10pt" Text="Comentarios"></asp:Label>
                        </td>
                        <td class="auto-style33">
                            <asp:TextBox ID="txtComentario" runat="server" MaxLength="400" name="txtcomentario" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <tr align="center">
                    <td>
                    <td  ><asp:Button ID="btn_guardado" runat="server" CssClass="BotonAzul" Text="Agregar" OnClick="GuardarIngreso" Height="69px" Width="118px"></asp:Button></td>
                    </td>
                </tr>
            </div>
            <table class="Tabla_Estructura">
            </table>
</div>
    </asp:Panel> 
    <asp:Panel ID="PanelDetalle" runat="server" Width="1697px" Height="521px" style="margin-top: 245px">
    </asp:Panel>
</body>
</asp:Content>

