<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtistDetail.aspx.cs" Inherits="ProjectLabPsd.Views.ArtistDetail" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Artist Detail</title>
    <link href="Styling/Header.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .picture {
            height: 111px;
            width: 122px;
        }
    </style>
    
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
                        
                        <asp:Image ID="artistimg" ImageUrl="" runat="server"/>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Artist Id:"></asp:Label>
                        <asp:Label ID="idLbl" runat="server" Text=''></asp:Label>
                        <br />
                        <h3>Artist Name : </h3>
                        <asp:Label ID="nameLbl" runat="server" Text=''></asp:Label>
                        <br />
                        
                        

                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
                        <ItemTemplate>

                            <img id="Image1" src="../Assets/Albums/<%# Eval("Image")%>" alt="..." Width ="100px" height ="100px">
                            <br />
                            <asp:Label ID="idsLbl" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            <br />
                            <asp:Label ID="name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            <br />
                            <asp:Label ID="price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                            <br />
                            <asp:Label ID="desc" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                            <br />
                        
                <%if(Session["Role"] != null && Session["Role"].ToString() == "admin")
                    { %>
                    <asp:Button ID="UpdateAlbumBtn" runat="server" Text="Update Album" OnClick="UpdateAlbumBtn_Click" CommandArgument ='<%#Eval("id") %>' />
                    <asp:Button ID="DeleteAlbumBtn" runat="server" Text="Delete Album" OnClick="DeleteAlbumBtn_Click" CommandArgument= '<%# Eval("name") %>'/>
                        <br />
                <%} %>

                    
                   <asp:Button Id="selectbtn1" runat="server" Text="select" OnClick="selectbtn_click" CommandArgument='<%# Eval("Id") %>'/>
                            <br />
                   
                </ItemTemplate>
                </asp:Repeater>
            <br />
              

            <br /> 

            <%if(Session["Role"] != null && Session["Role"].ToString() == "admin")
             { %>
            <asp:Button ID="artistDetailInsertBtn" runat="server" Text="Insert Album" OnClick="artistDetailInsertBtn_Click" />
            <asp:Label ID="notifLbl1" runat="server" Text=""></asp:Label>
            <%} %>
            </div>
        
    </form>
</body>
</html>