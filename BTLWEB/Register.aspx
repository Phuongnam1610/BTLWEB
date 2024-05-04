<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="Register.aspx.cs" Inherits="BTLWEB.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./assets2/css/register.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <form id="registerForm" method="post" runat="server">
        <label for="username">Tên người dùng:</label>
        <input type="text" id="username" name="username" required><br>
        <br>

        <label for="email">Email:</label>
        <input type="email" id="email" name="email" required><br>
        <br>

        <label for="password">Mật khẩu:</label>
        <input type="password" id="password" name="password" required><br>
        <br>

        <asp:Button ID="btnSubmit" runat="server" Text="Đăng Ký" CssClass="your-css-class" OnClick="btnRegister_Click" />
    </form>

    <p id="message" runat="server"></p>


</asp:Content>
