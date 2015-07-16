<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportList.aspx.cs" Inherits="SignetSSRProject.Reports.ReportList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
        
         #form1 {
            height: 317px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <cc1:ModalPopupExtender ID="Label1_ModalPopupExtender" runat="server" PopupControlID="panel1"  CancelControlID="close"
            TargetControlID="linkbtn1" BackgroundCssClass="Background">
        </cc1:ModalPopupExtender>
    
        <asp:Label ID="Label1" runat="server" Text="Welcome to Reports page"></asp:Label>
    
    </div>
        <asp:LinkButton ID="linkbtn1" runat="server" OnClick="linkbtn1_Click" style="z-index: 1; left: 11px; top: 60px; position: absolute">Total Project Hours Worked By Job Classification</asp:LinkButton>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:LinkButton ID="linkbtn2" runat="server" style="z-index: 1; left: 7px; top: 98px; position: absolute; height: 20px">Project hours worked weely</asp:LinkButton>
        <p>
            <asp:Button ID="btn_reportlink" runat="server" OnClick="btn_reportlink_Click" style="position: relative; top: 226px; left: 1px; height: 19px;" Text="Report Links" />
        </p>
        <asp:Panel ID="panel1" runat="server"
            CssClass="Popup" align="center" style = "display:none">
    <iframe style=" width: 350px; height: 300px;" id="irm1" src="ReportCustomize.aspx" runat="server"></iframe>
   <br/>
    <asp:Button ID="close" runat="server" Text="Close Window" />
        </asp:Panel>
        
        <asp:LinkButton ID="linkbtn3" runat="server" style="z-index: 1; left: 11px; top: 135px; position: absolute">Hours Worked by Employee</asp:LinkButton>
        <asp:LinkButton ID="linkbtn4" runat="server" style="z-index: 1; left: 10px; top: 174px; position: absolute">Employee Hours Worked Weekly</asp:LinkButton>
        
    </form>
</body>
</html>
