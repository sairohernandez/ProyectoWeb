<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="PrograWeb.reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms"   Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">

        <asp:Label Text ="Rango de fechas desde" runat="server"></asp:Label>
        <asp:TextBox ID="txtFechaInicial" TextMode="Date"  required="true"  runat="server"></asp:TextBox>
        
        <asp:Label Text =" hasta " runat="server"></asp:Label>
        <asp:TextBox ID="txtFechaFinal" TextMode="Date"   required="true"  runat="server"></asp:TextBox>

        <asp:Button ID="btnProcesar" class="btn btn-success" runat="server" Text="Procesar" OnClick="btnProcesar_Click" />

       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
        <div style="margin-top:10px">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Hight="1000px"  Width="100%"   BorderColor="Gray" BorderWidth="0px" ></rsweb:ReportViewer>
        </div>
    </div>

</asp:Content>
