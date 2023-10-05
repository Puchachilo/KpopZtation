<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlbumInsert.aspx.cs" Inherits="ProjectLabPsd.Views.AlbumInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Album</title>
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
        <h1>Insert Album</h1>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

            <asp:Label ID="artistLbl" runat="server" Text="ArtistId"></asp:Label>
            <asp:TextBox ID="artistTxt" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>

            <br />

            <asp:Label ID="descLbl" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="descTxt" runat="server"></asp:TextBox>

            <br /> 

            <asp:Label ID="priceLbl" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>

            <br /> 

            <asp:Label ID="stockLbl" runat="server" Text="Stock"></asp:Label>
            <asp:TextBox ID="stockTxt" runat="server"></asp:TextBox>

            <br />

            <asp:Label ID="imageLbl" runat="server" Text="Image"></asp:Label>
            <asp:FileUpload ID="imageUp" runat="server" />

            <br /> 

            <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click" />
            <br />
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
