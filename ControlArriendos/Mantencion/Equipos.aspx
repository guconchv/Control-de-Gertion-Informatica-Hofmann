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

    <script> 
        function confirmar() {
            var x;
            if (confirm("¿Desea agregar otro registro?") == true)
            {
                 x = "Has pulsado OK!";
            }
            else {
                 x = "Has pulsado cancel!";
                 }
            document.getElementById("demo").innerHTML = x;
}
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
           <asp:Label ID="Label5" runat="server" CssClass="Texto" Text="RUT" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" >
           <asp:TextBox ID="txtrut" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label6" runat="server" CssClass="Texto" Text="NOMBRE" Font-Size="10pt"></asp:Label>
        </td>
        <td class="auto-style12" >
           <asp:TextBox ID="txtNombre" MaxLength="80" required="active" runat="server" Height="17px"  Width="133px" onkeypress="return soloLetras(event)" CssClass="textbox"></asp:TextBox>
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
          <asp:TextBox ID="txtdepartamento" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>                        
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
      <tr aling="center">
         <td class="auto-style20" style="width: 148px">
            <asp:Label ID="Label80" runat="server" CssClass="Texto" Font-Size="10pt" Text="FECHA INGRESO :"></asp:Label>
         </td>
         <td class="auto-style30">
            <asp:TextBox ID="txt_fecha" runat="server" CssClass="textbox" required="active" Enabled="True" Height="16px" style=" text-align: center" Width="130px"></asp:TextBox>
         </td>
         <td class="auto-style20" style="width: 148px">
            <asp:Label ID="Label11" runat="server"  CssClass="Texto" Font-Size="10pt" Text="TIPO :"></asp:Label>
         </td>
         <td class="auto-style29">
            <asp:TextBox ID="txttipo" runat="server" required="active" Height="16px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
         </td>
       </tr>
       <tr align="center">
        <td class="auto-style14" >
            <asp:Label ID="Label16" runat="server" CssClass="Texto" Text="INGRESADO POR  :" Font-Size="10pt"></asp:Label>
       </td>        
          <td class="auto-style29">
            <asp:TextBox ID="txttecnico" runat="server" required="active" Height="16px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>                
        </td>

        <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label17" runat="server" CssClass="Texto" Text="LICENCIA OFFICE :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style20" >
           <asp:TextBox ID="txtOffice" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
           
         <tr align ="center">
            <td class="auto-style20" style="width: 148px">
           <asp:Label ID="Label18" runat="server" CssClass="Texto" Text="LICENCIA WINDOWS :" Font-Size="10pt"></asp:Label>
        </td>
             <td class="auto-style29" >
           <asp:TextBox ID="txtwindows" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
             <td class="auto-style21" style="width: 148px">
           <asp:Label ID="Label15" runat="server" CssClass="Texto" Text="FACT. RELACIONADA :" Font-Size="10pt"></asp:Label>
        </td>
             <td class="auto-style29" >
           <asp:TextBox ID="txtfactura" runat="server" required="active" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
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
                            <asp:TextBox ID="txtcodigo" runat="server" required="active" MaxLength="30" name="txtequipo"></asp:TextBox>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="Label8" runat="server" CssClass="Texto" Font-Size="10pt" Text="Hardware"></asp:Label>
                        </td>
                        <td class="auto-style29">
                            <asp:TextBox ID="txtHardware" runat="server" required="active" MaxLength="30" name="txthardware" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td class="auto-style20" style="width: 90px">
                            <asp:Label ID="Label9" runat="server" CssClass="Texto" Font-Size="10pt" Text="Marca"></asp:Label>
                        </td>
                        <td class="auto-style30">
                            <asp:TextBox ID="txtMarca" runat="server" required="active" MaxLength="30" name="txtmarca"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style29">
                            <asp:Label ID="Label12" runat="server" CssClass="Texto" Font-Size="10pt" Text="Modelo"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:TextBox ID="txtModelo" runat="server" required="active" MaxLength="30" name="txtmodelo"></asp:TextBox>
                        </td>
                        <td class="auto-style29">
                            <asp:Label ID="Label13" runat="server" CssClass="Texto" Font-Size="10pt" Text="Serie"></asp:Label>
                        </td>
                        <td class="auto-style32">
                            <asp:TextBox ID="txtSerie" runat="server" required="active" MaxLength="30" name="txtsodelo"> </asp:TextBox>
                        </td>
                        <td class="auto-style29" style="width: 90px">
                            <asp:Label ID="Label14" runat="server" CssClass="Texto" Font-Size="10pt" Text="Comentarios"></asp:Label>
                        </td>
                        <td class="auto-style33">
                            <asp:TextBox ID="txtComentario" runat="server" required="active" MaxLength="400" name="txtcomentario" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <tr align="center">
                    <td ><asp:Button ID="btn_guardado" runat="server" CssClass="BotonAzul" Text="Agregar" OnClick="GuardarIngreso" Height="42px" Width="94px"></asp:Button></td>
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

