<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="ProjectLabPsd.Views.TransactionReport1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction Report</title>
    <link href="Styling/Header.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" SortExpression="TransactionId" />
                    <asp:BoundField DataField="GrandTotal" HeaderText="GrandTotal" ReadOnly="True" SortExpression="GrandTotal" />
                </Columns>
        </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ArtistConnection %>" SelectCommand="SELECT TransactionId, SUM(SubTotal) AS GrandTotal FROM TransactionDetail GROUP BY TransactionId "></asp:SqlDataSource>
        </div>
        
    </form>
</body>
</html>
