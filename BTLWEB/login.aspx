<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Layout.Master" CodeBehind="login.aspx.cs" Inherits="BTLWEB.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        /* Add your CSS styles here */
        label {
            display: block;
            margin-top: 10px;
        }
        input[type="text"], input[type="password"] {
            width: 200px;
            padding: 5px;
            margin: 5px 0;
        }
        #loginButton {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }
        #loginButton:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <div>
                <label for="Email">Email:</label>
                <asp:TextBox ID="tbemail" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="password">Password:</label>
                <asp:TextBox ID="tbpassword" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="loginButton" CssClass="btn" UseSubmitBehavior="false" runat="server" Text="Login" OnClick="loginButton_Click" />
            </div>
            <p id="wrongp" runat="server" style="visibility:hidden;">Sai TK MK!</p>
            <p>
                If you don't have an account, <a href="Register.aspx">register here</a>.
            </p>
        </div>
    </form>
</body>
</html>
    </asp:Content>
