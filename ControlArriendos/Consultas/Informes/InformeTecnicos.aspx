<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InformeTecnicos.aspx.cs" Inherits="ControlArriendos.InformeTecnicos" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width:100%; height: 405px;">
        <tr>
            <td style="width: 413px">
    <asp:ImageButton ID="ImageButton2" runat="server" style="float:right" ImageUrl="~/Imagenes/iconos/atras.png" Height="63px" OnClick="ImageButton3_Click" Width="86px" />

            </td>
            <td rowspan="3" style="width: 982px">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="956px" BackColor="#99FFCC" BorderStyle="Groove" Font-Names="Verdana" Font-Size="8pt" LinkDisabledColor="Red">
                </rsweb:ReportViewer>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 413px; height: 212px;"></td>
            <td style="height: 212px"></td>
        </tr>
        <tr>
            <td style="width: 413px; height: 37px;"></td>
            <td style="height: 37px"></td>
        </tr>
    
</table>    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
  
</asp:Content>

