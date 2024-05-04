<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="UpPost.aspx.cs" Inherits="BTLWEB.UpPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thêm bài viết mới</title>
    <link rel="stylesheet" href="./assets2/css/uppost.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <%--   <script>
            document.addEventListener('DOMContentLoaded', function () {
                document.querySelector('form').addEventListener('submit', function (event) {
                    var title = document.getElementById('title').value;
                    var content = document.getElementById('content').value;
                    if (title.trim() === '' || content.trim() === '') {
                        event.preventDefault();
                        alert('Tiêu đề hoặc nội dung không được để trống');
                    }
                });
            });
        </script>--%>

    <div class="container">
        <h2>Thêm bài viết mới</h2>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="postadd">
                        <label for="title">Tiêu đề:</label><br>
                        <input id="title" runat="server" type="text" name="title" required><br>
                        <br>

                        <label for="content">Nội dung:</label><br>
                        <textarea id="content" runat="server" name="content" rows="4" required></textarea><br>
                        <br>
                        <asp:DropDownList ID="cateselect" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Thêm bài viết" aria-label="like this post" title="like this post" />
                    </div>


                    <div class="topic" style="padding:3px;">
                        <asp:Repeater ID="rptPost" runat="server" OnItemDataBound="RptTopic_ItemDataBound">
                            <ItemTemplate>
                                <div class="topic-container">
                                    <div class="post-wrap tpwrap">
                                        <div class="headtp">
                                            <div class="infouser">
                                                <img alt="" width="45" height="45" src="./Image/<%#Eval("user.profilepicture")%>" class="avatar">
                                                <span class="topic-name-user"><%#Eval("user.username")%></span>
                                            </div>
                                            <span class="tpdate"><%#Eval("datetime")%></span>
                                        </div>
                                        <div class="topic-content">
                                            <div class="reply-to" runat="server" id="replyto">
                                                <p><%#Eval("title")%></p>
                                            </div>
                                            <div class="cooked">
                                                <p runat="server" id="topicContent"><%#Eval("content")%></p>
                                            </div>
                                            <div class="post-menu-area">

                                                <asp:Label ID="lbDuyet" runat="server" CommandArgument='<%#Eval("postid")%>' Text="Duyệt" />

                                                <asp:Button ID="btnXoa" runat="server" CommandArgument='<%#Eval("postid")%>' Text="Xóa" CssClass="btn" OnClick="btnXoa_Click" />



                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>

                </ContentTemplate>

            </asp:UpdatePanel>

        </form>



    </div>

</asp:Content>
