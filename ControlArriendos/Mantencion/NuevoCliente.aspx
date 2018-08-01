﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoCliente.aspx.cs" Inherits="ControlArriendos.Mantencion.NuevoCliente" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
     <%--    *************************    Mostrar fecha   *************************************    --%>
<link rel="stylesheet" type="text/css" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
     <script>
         $(document).ready(function () {
             $('#<%=txt_fecha.ClientID%>').datepicker({
                 dateFormat: 'dd-mm-yy',
                 minDate: new Date('2000/01/01'),
                 maxDate: "+0m +0d",
                 changeMonth: true,
                 changeYear: true
             }).val();
         });
      </script>
 <script>
     function validarEmail(email) {
         expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
         if (!expr.test(email))
             alert("Error: La dirección de correo " + email + " es incorrecta.");
     }
</script>
    <%--    *************************    Funsion solo Letras Jquery    *************************************    --%>
<script>
    function soloLetras(e) {
        key = e.keyCode || e.which;
        tecla = String.fromCharCode(key).toLowerCase();
        letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
        especiales = "8-37-39-46";

        tecla_especial = false
        for (var i in especiales) {
            if (key == especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        if (letras.indexOf(tecla) == -1 && !tecla_especial) {
            return false;
        }
    }
</script>
    <%--    *************************    Funsion solo Numeros Jquery    *************************************    --%>
    <script>
        function solonumeros(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = "1234567890";
            especiales = "8-37-39-46";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
</script>
<asp:Panel ID="PanelPrincipal" runat="server" Width="1700px">
     <body > 
<body>

    <div  align="center" style="width: 1700px">
       <br />
        <br />
         <h2 class="Titulos">Nuevo Cliente </h2>
        <br />
        <table  class="Tabla_Estructura">
            <center>
                <tr align="center">
       <td class="auto-style14" style="height: 37px" >
           <asp:Label ID="Label5" runat="server" CssClass="Texto" Text="RUT :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" style="height: 37px" >
           <asp:TextBox ID="txtRut" MaxLength="18" required="active" runat="server" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px; height: 37px;">
           <asp:Label ID="Label6" runat="server" CssClass="Texto" Text="NOMBRE :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29" style="height: 37px"><asp:TextBox ID="txtNombre" MaxLength="80" required="active" runat="server" Height="17px"  Width="133px" onkeypress="return soloLetras(event)" CssClass="textbox"></asp:TextBox>                                  
        </td>             
    </tr>
                <tr align="center">
       <td class="auto-style14" style="height: 37px" >
           <asp:Label ID="Label1" runat="server" CssClass="Texto" Text="DIRECCION :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" style="height: 37px" >
           <asp:TextBox ID="txtDireccion" MaxLength="100" required="active" runat="server" Height="16px" Width="130px" CssClass="textbox" OnTextChanged="txtDireccion_TextChanged"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px; height: 37px;">
           <asp:Label ID="Label3" runat="server" CssClass="Texto" Text="COMUNA :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29" style="height: 37px">
                                            
           <asp:DropDownList ID="DropComuna" TextDefault="Seleccione" Class="ComboBox" runat="server" Height="29px" Width="140px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="textbox">
           </asp:DropDownList>
                                            
        </td>             
    </tr>
               <tr align="center">
       <td class="auto-style14" style="height: 37px" >
           <asp:Label ID="Label2" runat="server" CssClass="Texto" Text="CORREO ELECTRONICO :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" style="height: 37px" >
           <asp:TextBox ID="txtCorreo" MaxLength="50" required="active" runat="server" Height="16px" Width="130px" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px; height: 37px;">
           <asp:Label ID="Label8" runat="server" CssClass="Texto" Text="CIUDAD :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29" style="height: 37px">
           <asp:DropDownList ID="DropCiudad" TextDefault="Seleccione" Class="ComboBox" runat="server" Height="33px" Width="140px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="textbox">
           </asp:DropDownList>                         
        </td>             
    </tr>
               <tr align="center">
       <td class="auto-style14" style="height: 37px" >
           <asp:Label ID="Label4" runat="server" CssClass="Texto" Text="TELEFONO FIJO :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" style="height: 37px" >
           <asp:TextBox ID="txtFijo" required="active" MaxLength="20" runat="server" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px; height: 37px;">
           <asp:Label ID="Label9" runat="server" CssClass="Texto" Text="ESTADO :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29" style="height: 37px">
           <asp:DropDownList ID="DropEstado" TextDefault="Seleccione"  runat="server" Height="30px" Width="140px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" class="Combobox" CssClass="textbox">
           </asp:DropDownList>                 
        </td>             
    </tr>
               <tr align="center">
       <td class="auto-style14" style="height: 37px" >
           <asp:Label ID="Label10" runat="server" CssClass="Texto" Text="TELEFONO MOVIL :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style12" style="height: 37px" >
           <asp:TextBox ID="txtMovil" required="active" MaxLength="20" runat="server" Height="16px" Width="130px" onkeypress="return solonumeros(event)" CssClass="textbox" OnTextChanged="txtMovil_TextChanged"></asp:TextBox>
        </td>
       <td class="auto-style20" style="width: 148px; height: 37px;">
           <asp:Label ID="Label11" runat="server" CssClass="Texto" Text="FECHA INGRESO :" Font-Size="10pt"></asp:Label>
        </td>
       <td class="auto-style29" style="height: 37px">
            <asp:TextBox ID="txt_fecha" runat="server"  Height="16px" Width="130px" Enabled="True" CssClass="textbox" style=" text-align: center"></asp:TextBox>                   
        </td>             
    </tr>
       <tr align="center">
       <td class="auto-style14" >
           
        </td>
       <td class="auto-style12" >
           <asp:Button ID="BtnAgregar" type="submit" runat="server" Text="AGREGAR" CssClass="BotonAzul" OnClick="AgregarCliente_Click" />
        </td>
       <td class="auto-style20" style="width: 148px">
           <asp:HyperLink ID="HyperLink1" runat="server" Text="VOLVER" ControlStyle-CssClass="BotonRojo" NavigateUrl="Clientes.aspx" />
           <ControlStyle CssClass="BotonRojo" ></ControlStyle>
           </asp:HyperLink>
        </td>
       <td class="auto-style29">
                                
        </td>             
    </tr>
         </center>
         </table>
     </div>
     <br />
     <br />
    
</body>
     </asp:Panel> 
    </asp:Content>
