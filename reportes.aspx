<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="PrograWeb.reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms"   Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="content">


       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Hight="1000px"  Width="100%"   BorderColor="Gray" BorderWidth="0px" ></rsweb:ReportViewer>

    </div>
</asp:Content>
