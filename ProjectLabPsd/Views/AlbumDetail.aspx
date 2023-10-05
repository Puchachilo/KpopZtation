<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlbumDetail.aspx.cs" Inherits="ProjectLabPsd.Views.AlbumDetail" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Album Detail</title>
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
            <h3> Album Detail</h3>

            
                         <div>
                     
                             <asp:Image ID="Image1" ImageUrl="" runat="server" />
                            <%--<img id="Image1" src="../Assets/Albums/<%# Eval("Image")%>" alt="..." Width ="100px" height ="100px">--%>
                            
                            <br />
                               <h3>Album Name</h3>
                            <asp:Label ID="nameLbl" runat="server" Text=""></asp:Label>
                            <br />
                               <h3>Album Price</h3>
                            <asp:Label ID="priceLbl" runat="server" Text=""></asp:Label>
                            <br />
                               <h3> Album Stock</h3>
                            <asp:Label ID="stockLbl" runat="server" Text =""></asp:Label>
                            <br />
                               <h3>Album Description</h3>
                            <asp:Label ID="descLbl" runat="server" Text=""></asp:Label>
                            <br />
                                                      
                         </div>
            <div>

            </div>
             <%if(Session["Role"] != null && Session["Role"].ToString() == "user")
                    { %>
                    <asp:Label ID="qtyLbl" runat="server" Text="Quantity:"></asp:Label>
                    <asp:TextBox ID="qtyTxt" runat="server"></asp:TextBox>
            
                   
            <br />
                <asp:Button ID="atcBtn" runat="server" Text="Add to Cart" OnClick="atcBtn_Click"  CommandArgument='<%# Eval("Id") %>'/>
         <%} %>
            </div>
    </form>
</body>
</html>
