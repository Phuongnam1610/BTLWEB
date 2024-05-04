<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="ManagePost.aspx.cs" Inherits="BTLWEB.ManagePost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./assets2/css/managepost.css">
    <title>Duyệt bài</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div class="container">
        <h2>Kiểm duyệt</h2>
        <form id="form1" runat="server">



            <div class="container-wrap">
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="topic" style="border: 1px solid #808080; padding: 3px">
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

                                                    <asp:Button ID="btnDuyet" runat="server" CommandArgument='<%#Eval("postid")%>' Text="Duyệt" UseSubmitBehavior="false" CssClass="btn" OnClick="btnDuyet_Click"   />
                                                    <asp:Button ID="btnXoa" runat="server" CommandArgument='<%#Eval("postid")%>' Text="Xóa" CssClass="btn" OnClick="btnXoa_Click"   />
                                                    <asp:Button ID="btnViPham" runat="server" CommandArgument='<%#Eval("userid")%>' Text="Vi Phạm" CssClass="btn" OnClick="btnViPham_Click"   />



                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>

                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>

        </form>



    </div>

</asp:Content>
