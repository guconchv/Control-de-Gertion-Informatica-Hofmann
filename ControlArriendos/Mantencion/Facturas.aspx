<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="ControlArriendos.Mantencion.Facturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
