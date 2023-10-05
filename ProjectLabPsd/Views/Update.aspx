<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="ProjectLabPsd.Views.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update</title>
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
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ArtistConnection %>" SelectCommand="SELECT [Name], [Image] FROM [Artist]" UpdateCommand="UPDATE [Artist] SET[Name] = @Name, [Image] = @Image WHERE [Id] = @Id">

                 <UpdateParameters>
                     <asp:Parameter Name="Name" Type="String" />
                     <asp:Parameter Name="Image" Type="Byte" />
                     <asp:Parameter Name="Id" Type="Int32" />
                 </UpdateParameters>

             </asp:SqlDataSource>
            <br />
            <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="imageLbl" runat="server" Text="Image"></asp:Label>
            <asp:FileUpload ID="imageUp" runat="server" />
            <br />
            <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click"/>
            <br />
            <asp:Label ID="notifLbl" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
