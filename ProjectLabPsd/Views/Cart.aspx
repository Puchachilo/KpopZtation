<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ProjectLabPsd.Views.Cart" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
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
            
                           <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                           <ItemTemplate>

                            <img id="Image1" src="../Assets/Albums/<%# Eval("Image")%>" alt="..." Width ="100px" height ="100px">
                            <br />

                            <br />
                               <h3>Album Name</h3>
                            <asp:Label ID="name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            <br />
                               <h3>Album Price</h3>
                            <asp:Label ID="price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                            <br />   
                               <h3>Quantity</h3>
                             <asp:Label ID="qtyLbl" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                              <br />

                               <asp:Button ID="removeBtn" runat="server" Text="Remove" OnClick="removeBtn_Click" CommandArgument='<%# Eval("AlbumId") %>' />
                               <br>
                               
                           </ItemTemplate>
                       </asp:Repeater>        

                            <asp:Button ID="coBtn" runat="server" Text="Check Out" OnClick="coBtn_Click" style="height: 29px" />
                               <br />

        </div>
    </form>
</body>
</html>
