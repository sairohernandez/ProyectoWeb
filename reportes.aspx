<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportes.aspx.cs" Inherits="PrograWeb.reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms"   Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


      <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Height="1000px" Width="1200px"   BorderColor="Gray" BorderWidth="0px" ></rsweb:ReportViewer>
<%--          <rsweb:ReportViewer ID="rptEtiqueta" runat="server" Height="100%" 
                           Width="1200px" AsyncRendering="False" SizeToReportContent="false" 
                           BackColor="White" BorderColor="Gray" BorderWidth="0px" >
               </rsweb:ReportViewer>--%>
    </div>
    </form>
  
</body>
</html>
