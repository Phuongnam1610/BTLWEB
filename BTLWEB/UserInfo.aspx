<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="BTLWEB.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User</title>
    <link rel="stylesheet" href="./assets2/css/userinfo.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="containerpf">
                    <div class="profile">
                        <img class="avatar" src="./Image/default.jpg" alt="Avatar">

                        <div class="info">
                            <asp:FileUpload ClientIDMode="Static" OnUploadedFile="fileUpload_UploadedFile" ID="fileUpload" CssClass="btn" runat="server" Style="display: none;" />
<asp:Label ID="changeAvaLabel" runat="server" Text="Đổi Avatar" CssClass="btn" OnClick="document.getElementById('fileUpload').click();" style="cursor: pointer;" />

                            <p id="username" runat="server"><strong>Username:</strong> JohnDoe</p>
                            <p id="email" runat="server"><strong>Email:</strong> johndoe@example.com</p>
                            <p id="isadmin" runat="server"><strong>IsAdmin:</strong> Yes</p>
                            <p id="ban" runat="server"><strong>BAN:</strong> No</p>
                            <asp:Button ID="btnLogout" runat="server" Text="Đăng xuất" CssClass="btn" OnClick="btnLogout_Click" />

                        </div>

                    </div>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>

    </form>
</asp:Content>


