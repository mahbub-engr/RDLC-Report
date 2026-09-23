<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportUI.aspx.cs" Inherits="RDLC_Report.UI.ReportUI" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Student ID"></asp:Label>
            <asp:TextBox runat="server" ID="TextID"></asp:TextBox> <br />
            <asp:Button ID="LoadReport" runat="server" Text="Get Student" OnClick="LoadReport_Click" />
        </div>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="185px" InteractivityPostBackMode="AlwaysSynchronous" ShowBackButton="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowRefreshButton="False" ShowZoomControl="False" Width="1080px" ZoomMode="PageWidth"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
