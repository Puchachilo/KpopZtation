<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs"  Inherits="ProjectLabPsd.Views.Home" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="Styling/Header.css" rel="stylesheet" type="text/css" />
    <link href="Styling/homePic.css" rel="stylesheet" type="text/css" />
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
            <h1 class="title">Artist</h1>
            <br />
            <div class="container-profile">
               <asp:Repeater ID="artistRptr" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="artistRptr_ItemCommand">
               <ItemTemplate> 
                   <div class="profile-home">
                       <h3 class="name"><%# Eval("Name") %></h3>
                       
                       <img class="picture" src='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' alt="<%# Eval("Name") %>" />
                       
                       <div class="action">
                        <%if (Session["Role"] != null && Session["Role"].ToString() == "admin" )
                            { %>
                            <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" CommandArgument='<%# Eval("id") %>'/>
                            <asp:Button ID="deleteBtn" runat="server" Text="Delete" OnClick="deleteBtn_Click" CommandArgument='<%# Eval("name") %>'/>
                            
                            <%} %>
                          
                             <asp:Button Id="selectbtn1" runat="server" Text="select" OnClick="selectbtn_click" CommandArgument='<%# Eval("Id") %>'/>     
                          
                       </div>
                   </div>     
                    
            </ItemTemplate>
            </asp:Repeater>
            </div>
            

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ArtistConnection %>" SelectCommand="SELECT [Id], [Name], [Image] FROM [Artist]"></asp:SqlDataSource>

            <br />
            <%if(Session["Role"] != null && Session["Role"].ToString() == "admin")
             { %>
            <asp:Button ID="artistInsertBtn" runat="server" Text="Insert" OnClick="artistInsertBtn_Click" />
            <asp:Label ID="notifLbl" runat="server" Text=""></asp:Label>
            <%} %>
        </div>
    </form>
</body>
</html>
