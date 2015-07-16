<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportCustomize.aspx.cs" Inherits="SignetSSRProject.Reports.ReportCustomize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 323px">
    <form id="form1" runat="server">
    <div style="height: 458px">
    
        <br />
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 10px; top: 18px; position: absolute" Text="Customize your report"></asp:Label>
        
        <asp:Calendar ID="begindate" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" style="z-index: 1; left: 10px; top: 124px; position: absolute; height: 142px; width: 118px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
        <asp:Calendar ID="enddate" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" ShowGridLines="True" style="z-index: 1; left: 192px; top: 124px; position: absolute; height: 136px; width: 94px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 16px; top: 94px; position: absolute" Text="Begin Date:"></asp:Label>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 16px; top: 55px; position: absolute; right: 902px" Text="Job type:"></asp:Label>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 194px; top: 90px; position: absolute" Text="End Date:"></asp:Label>
        <asp:RadioButton ID="radiodownloadview" runat="server" GroupName="Report1" style="z-index: 1; left: 3px; top: 282px; position: absolute; " Text="Download &amp; View" AutoPostBack="True" />
        <asp:RadioButton ID="radioview" runat="server" style="z-index: 1; left: 213px; top: 284px; position: absolute; width: 108px; height: 20px;" Text="View Only" AutoPostBack="True" GroupName="Report1" />
        <asp:Button ID="download" runat="server" style="z-index: 1; left: 21px; top: 312px; position: absolute" Text="Download" />
        <asp:Button ID="viewonly" runat="server" style="z-index: 1; left: 249px; top: 313px; position: absolute" Text="View" OnClick="viewonly_Click1"    />
    
        <asp:DropDownList ID="ddljobtype" runat="server" AppendDataBoundItems="True" style="z-index: 1; left: 79px; top: 57px; position: absolute; height: -2px; width: 128px">
            <asp:ListItem>Select Jobtype</asp:ListItem>
            <asp:ListItem>DNU_In-house</asp:ListItem>
            <asp:ListItem>Billable Hours</asp:ListItem>
            <asp:ListItem>Affiliated</asp:ListItem>
            <asp:ListItem>Billable Hours</asp:ListItem>
            <asp:ListItem>Machine In-house</asp:ListItem>
            <asp:ListItem>Machine Billable Hours</asp:ListItem>
            <asp:ListItem>DNU_Machine In_Machine</asp:ListItem>
            <asp:ListItem>DNU_Machine Billable Hours</asp:ListItem>
            <asp:ListItem>Paid Time Off</asp:ListItem>
            <asp:ListItem>Crescent Towing</asp:ListItem>
            <asp:ListItem>Crescent Towing</asp:ListItem>
            <asp:ListItem>DNU_New In-house</asp:ListItem>
            <asp:ListItem>In-house</asp:ListItem>
        </asp:DropDownList>
    
        
    
    </div>
    </form>
</body>
</html>
