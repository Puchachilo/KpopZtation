<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="ProjectLabPsd.Views.Transactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction History</title>
    <link href="Styling/Header.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav id="navbar">
                <ul>
                    <li><a href="Home.aspx">Home</a></li>
                    <% if (Session["Role"] == null) { %>
                        <li><a href="Login.aspx">Login</a></li>
                        <li><a href="Register.aspx">Register</a></li>
                    <% } else if (Session["Role"].ToString() == "user") { %>
                        <li><a href="Cart.aspx">Cart</a></li>
                        <li><a href="Transactions.aspx">Transactions</a></li>
                        <li><a href="UpdateProfile.aspx">Update Profile</a></li>
                    <% } else if (Session["Role"].ToString() == "admin") { %>
                        <li><a href="TransactionReport.aspx">Transaction Report</a></li>
                        <li><a href="UpdateProfile.aspx">Update Profile</a></li>
                    <% } %>
                    <% if (Session["Role"] != null) { %>
                        <li><a href="Logout.aspx">Logout</a></li>
                    <% } %>
                </ul>
            </nav>

        </div>
            <div>



                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ArtistConnection %>" SelectCommand="SELECT td.TransactionDetailId, th.Date, cs.Name, al.Image, al.Name, al.Stock, al.Price FROM (((TransactionDetail AS td INNER JOIN Album AS al ON td.AlbumId = al.Id) INNER JOIN TransactionHeader AS th ON  th.Id = td.TransactionId) INNER JOIN Customer AS cs ON th.CustomerId = cs.Id);"></asp:SqlDataSource>



             </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TransactionDetailId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="TransactionDetailId" HeaderText="TransactionDetailId" InsertVisible="False" ReadOnly="True" SortExpression="TransactionDetailId" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:TemplateField HeaderText="Image" SortExpression="Image">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Image") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <img alt="" src="../Assets/Albums/<%# Eval("Image")%>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name1" HeaderText="Artist Name" SortExpression="Name1" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
