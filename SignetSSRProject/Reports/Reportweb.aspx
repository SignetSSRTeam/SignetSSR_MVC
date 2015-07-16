<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportweb.aspx.cs" Inherits="SignetSSRProject.Reports.Reportweb" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <rsweb:ReportViewer ID="myReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="439px" Width="871px">
            <ServerReport DisplayName="Reportweb" ReportPath="/SignetSSRReports/Total Project Hours Worked By Job Classification" ReportServerUrl="http://192.245.222.208/ReportServer" />
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
