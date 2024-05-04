<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Topic.aspx.cs" Inherits="BTLWEB.Topic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Topic</title>
    <link
        rel="stylesheet"
        href="./assets2/css/topic.css" />

    <script>
        function onValidateReply() {
            var content = document.querySelector(".content-reply").value;
            if (content.trim() === "") {
                alert("Textarea cannot be empty");
                return false;
            }
            return true;
        }

    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="topic">
                    <div class="topic-title">
                        <h1 runat="server" id="topicTitle">Làm thế nào nhập được dữ liệu từ bàn phím vào mongo?
                        </h1>
                    </div>
                    <div class="topic-container">
                        <div class="post-wrap tpwrap">
                            <div class="headtp">
                                <div class="infouser">
                                    <img alt="" width="45" height="45" src="./Image/oanh.jpg"class="avatar">
                                    <span class="topic-name-user">Gia Uy</span>
                                </div>
                                <span class="tpdate">4/1/2024 6:52:48 PM</span>
                            </div>
                            <div class="topic-content">
                                <div class="cooked">
                                    <p runat="server" id="topicContent">Mình thấy mn nhắc nhiều đến ngôn ngữ c++/c+pascal nhưng không biết đi thi học sinh giỏi được dùng ngôn ngữ c# để lập trình không bởi vì mình đam mê ngôn ngữ c# hơn 3 ngôn ngữ trên.</p>
                                </div>
                                <div class="post-menu-area">
                                    <div class="panelLike">
                                        <asp:Label ID="likesLabelP" runat="server" Text='0'></asp:Label>
                                        <img src="./Image/like.png" alt="lượt thích" />
                                        <div runat="server"></div>
                                    </div>
                                    <asp:Button ID="btnLikeP" runat="server" Text="Like" CssClass="btn" OnClick="btnLikeP_Click" aria-label="like this post" title="like this post" />
                                    <asp:Button ID="btnReplyP" runat="server" Text="Reply" CssClass="btn" OnClick="btnReplyP_Click" aria-label="Reply" />

                                </div>
                            </div>
                        </div>

                        <div class="container-wrap">
                            <asp:Repeater ID="rptComment" runat="server" OnItemDataBound="RptComment_ItemDataBound">
                                <ItemTemplate>
                                    <div class="row tpwrap">
                                        <div class="headtp">
                                            <div class="infouser">
                                                <img alt="" width="45" height="45" src="./Image/<%#Eval("user.profilepicture")%>" title="Gia Uy" class="avatar">
                                                <span class="topic-name-user"><%# Eval("user.username") %></span>
                                            </div>
                                            <span class="tpdate"><%# Eval("datetime") %></span>
                                        </div>
                                        <div class="tp-body">
                                            <div class="reply-to" runat="server" id="replyto">
                                                
                                            </div>
                                            <p><%# Eval("commenttext") %></p>
                                            <div class="post-menu-area">
                                                <div class="panelLike">
                                                    <asp:Label ID="likesLabel" runat="server" Text='<%# Eval("likecount") %>'></asp:Label>
                                                    <img src="./Image/like.png" alt="lượt thích" />
                                                </div>
                                                <asp:Button ID="btnLike" runat="server" CommandArgument='<%#Eval("commentID")%>' Text="Like" CssClass="btn" OnClick="btnLike_Click"/>
                                                <asp:Button ID="btnReply" runat="server" Text="Reply" CommandArgument='<%#Eval("commentID")%>' CssClass="btn" OnClick="btnReply_Click"/>

                                            </div>


                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <div id="reply_control" runat="server">
                            <div class="reply-area">
                                <div class="reply-to">
                                    <p class="reply-to-user" runat="server" id="replytouser"></p>
                                </div>
                                <textarea runat="server" class="content-reply" id="commentTextReply" cols="30" rows="10" placeholder="Nhập nội dung phản hồi"></textarea>
                                <div class="submit-panel">

                                    <asp:Button ID="btnSubmitReply" runat="server" Text="Submit" CssClass="btn Submit-button" OnClientClick="return onValidateReply();" OnClick="btnSubmitReply_Click" />

                                    <asp:Button ID="btnCancelReply" runat="server" Text="Cancel" CssClass="btn Cancel-button" OnClick="btnCancelReply_Click" />


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>

