<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master RVC.aspx.cs" Inherits="SignetSSRProject.Reports.Master_RVC" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 550px">
    <form id="form1" runat="server">
    <div style="height: 317px">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="lblMessage" runat="server" Text="Your Report has been downloaded" Visible="False"></asp:Label>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="948px">
            <ServerReport ReportServerUrl="http://192.245.222.208/reportserver" />
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
