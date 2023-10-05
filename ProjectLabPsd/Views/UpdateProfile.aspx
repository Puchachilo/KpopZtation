<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="ProjectLabPsd.Views.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Profile</title>
    <link href="Styling/Header.css" rel="stylesheet" type="text/css" />
</head>
<body>
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
    <form id="form1" runat="server">
        <div>
            <h3>Update Profile</h3>
            
            <br />
            <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
            <br />           
             <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="genderRadio" runat="server">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="addLbl" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="addTxt" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="passwordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="passTxt" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click"/>
            <br />
            
        </div>
    </form>
</body>
</html>
