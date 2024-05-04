<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BTLWEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang Chủ</title>
    <link
        rel="stylesheet"
        href="./assets2/css/home.css" />

    <script src="./assets2/js/home.js">

    </script>

    <script>
        window.addEventListener('pageshow', function (event) {
            var historyTraversal = event.persisted ||
                (typeof window.performance != 'undefined' &&
                    window.performance.navigation.type === 2);
            if (historyTraversal) {
                // Tải lại trang từ đầu
                window.location.reload();
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <select id="cateselect" onchange="onclickitemcate()">
        <asp:ListView ID="selectcate" runat="server">
            <ItemTemplate>
                <option value="<%#Eval("categoryID")%>">
                    <%#Eval("categoryname")%>
                </option>
            </ItemTemplate>
        </asp:ListView>
        <!-- Thêm các option khác nếu cần -->
    </select>

    <div class="container">
        <table id="alltopic" class="topic-list">
            <thead>
                <tr class="tablehead">
                    <!-- thẻ <th> được sử dụng để định nghĩa một ô tiêu đề -->
                    <th data-sort-order="topic">Topic</th>
                    <th data-sort-order="likes">Likes
                    </th>
                    <th data-sort-order="comments">Comments
                    </th>
                    <th data-sort-order="activity">Activity
                    </th>
                </tr>
            </thead>


            <tbody>
                <asp:Repeater ID="rpthome" runat="server">
                    <ItemTemplate>
                        <tr class="<%# Eval("PostID") %> <%# Eval("categoryid") %>">
                            <td class="main-link">
                                <a href='Topic.aspx?PostID=<%# Eval("PostID") %>'><%# Eval("Title") %></a>
                            </td>
                            <td><%# Eval("likeCount") %></td>
                            <td>
                                <%# Eval("commentCount") %>
                            </td>
                            <td>
                                <%# Eval("datetime") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>


</asp:Content>

