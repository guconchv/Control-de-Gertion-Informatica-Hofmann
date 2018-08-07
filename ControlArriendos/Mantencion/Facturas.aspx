<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="ControlArriendos.Mantencion.Facturas" %>
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
        <script>
         $(document).ready(function () {
             $('#<%=txtfechaingreso.ClientID%>').datepicker({
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
     <center><h2 class="Titulos">REGISTRO DE FACTURAS</h2></center>
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
           <asp:Label ID="Label5" runat="server" CssClass="Texto" Text="RUT EMPRESA" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" >
           <asp:TextBox ID="rut_empresa" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label6" runat="server" CssClass="Texto" Text="NOMBRE EMPRESA" Font-Size="10pt"></asp:Label>
        </td>
        <td class="auto-style12" >
           <asp:TextBox ID="nombre_empresa" MaxLength="80" required="active" runat="server" Height="17px"  Width="133px" onkeypress="return soloLetras(event)" CssClass="textbox"></asp:TextBox>
        </td>
    </tr>
    <caption>
            &nbsp;
        </caption>
                <tr align="center">
       <td class="auto-style14" >
           <asp:Label ID="Label1" runat="server" CssClass="Texto" Text="NRO DOCUMENTO:" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" >
           <asp:TextBox ID="documento" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px">
            <asp:Label ID="Label3" runat="server" CssClass="Texto" Font-Size="10pt" Text="FECHA DOCUMENTO :"></asp:Label>
         </td>
         <td class="auto-style30">
            <asp:TextBox ID="txt_fecha" runat="server" CssClass="textbox" required="active" Enabled="True" Height="16px" style=" text-align: center" Width="130px"></asp:TextBox>
         </td>
    </tr>
       <tr align="center">
       <td class="auto-style14" >
           <asp:Label ID="Label7" runat="server" CssClass="Texto" Text="TELEFONO  :" Font-Size="10pt"></asp:Label>
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
        <td class="auto-style14" >
            <asp:Label ID="Label16" runat="server" CssClass="Texto" Text="FECHA INGRESO  :" Font-Size="10pt"></asp:Label>
       </td>        
          <td class="auto-style29">
            <asp:TextBox ID="txtfechaingreso" runat="server" CssClass="textbox" required="active" Enabled="True" Height="16px" style=" text-align: center" Width="130px"></asp:TextBox>                
        </td>

        <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label17" runat="server" CssClass="Texto" Text="ORDEN DE COMPRA :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style20" >
           <asp:TextBox ID="txtOffice" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
         <tr align ="center">
            <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label18" runat="server" CssClass="Texto" Text="MONTO TOTAL :" Font-Size="10pt"></asp:Label>
        </td>
             <td class="auto-style29" >
           <asp:TextBox ID="montotal" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
             <td class="auto-style21" style="width: 148px">
           <asp:Label ID="Label11" runat="server" CssClass="Texto" Text="Detalle :" Font-Size="10pt"></asp:Label>
        </td>
             <td class="auto-style29" >
           <asp:TextBox ID="descripcion" runat="server" required="active" Height="60px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
        </td>
        </tr> 
           </tr>
         </center>
         </table>
            <div align="center" style="width: 1700px; height: 520px;">
                <table id="tabla" style="width: 757px; margin-top: 17px; margin-left: 0px;">
                </table>
                <tr align="center">
                    <td ><asp:Button ID="btn_guardado" runat="server" CssClass="BotonAzul" Text="Agregar" Height="42px" Width="94px"></asp:Button></td>
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
