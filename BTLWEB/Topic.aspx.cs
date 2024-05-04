using BTLWEB.DAO;
using BTLWEB.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTLWEB
{
    public partial class Topic : System.Web.UI.Page
    {
        int ChoiceRep = 0;
        string postID;
        User loggedInUser;
        List<Comment> comments;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInUser = (User)Session["User"];

            postID  = Request.QueryString["PostID"];
            Post p = PostDAO.Instance.GetPostByID(postID);
            if (p != null)
            {
                topicTitle.InnerText =p.Title;
                topicContent.InnerText =p.Content;
                comments = CommentDAO.Instance.GetListCommentByPostID(postID);
                if (!IsPostBack)
                {
                    rptComment.DataSource = comments;
                    rptComment.DataBind();
                    if (loggedInUser != null)
                    {
                        likesLabelP.Text = p.LikeCount.ToString();
                        if (PostLikeDAO.Instance.checkPostLike(postID, loggedInUser.Userid.ToString()))
                        {
                            btnLikeP.Text = "UnLike";
                        }
                    }
                }
            }
        }

        protected void RptComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Comment cmt = (Comment)e.Item.DataItem;

            if (Session["User"] != null)
            {
                User loggedInUser = (User)Session["User"];


                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Button btnLike = (Button)e.Item.FindControl("btnLike");



                    // Lấy user ID từ session
                    int loggedInUserID = loggedInUser.Userid;

                    // Kiểm tra nếu user ID khớp với user ID trong item template
                    if (CommentLikeDAO.Instance.checkCommentLike(cmt.Commentid.ToString(), loggedInUserID.ToString()))
                    {
                        btnLike.Text = "UnLike";
                    }


                }
            }
            HtmlGenericControl replyto = e.Item.FindControl("replyto") as HtmlGenericControl;



            // Lấy user ID từ item template
            if (cmt.Commentreply!=null)
            {
                replyto.Style["visibility"] = "visible";
                string s = "<p>Reply to: "+cmt.Commentreply.User.Username+"</p><p>"+cmt.Commentreply.Commenttext+"</p>";
                replyto.InnerHtml = s;
            }
            else
            {
                replyto.Style["visibility"] = "hidden";

            }
        }

        protected void btnLikeP_Click(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {

                Button btnLike = (Button)sender;
                int newLikeCount = Convert.ToInt32(likesLabelP.Text);

                if (btnLike.Text=="UnLike")
                {
                    PostLikeDAO.Instance.UnlikePost(postID, loggedInUser.Userid.ToString());
                    btnLike.Text = "Like";
                    likesLabelP.Text = (newLikeCount-1).ToString();
                }
                else
                {
                    PostLikeDAO.Instance.likePost(postID, loggedInUser.Userid.ToString());
                    likesLabelP.Text = (newLikeCount+1).ToString();
                    btnLike.Text = "UnLike";

                }


            }



        }

        protected void btnReplyP_Click(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                User loggedInUser = (User)Session["User"];
                commentTextReply.Value="";
                reply_control.Style["display"] = "block";
                replytouser.InnerText ="Reply To: "+loggedInUser.Username;
                Session["choicerep"] = 0 ;
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }


        protected void btnLike_Click(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                User loggedInUser = (User)Session["User"];

                Button btnLike = (Button)sender;
                // Lấy tham số commentID từ CommandArgument của nút like
                string commentID = ((Button)sender).CommandArgument;

                // Tìm phần tử cần cập nhật trong Repeater
                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
                Label lblLikeCount = item.FindControl("likesLabel") as Label;

                int newLikeCount = Convert.ToInt32(lblLikeCount.Text);

                if (btnLike.Text=="UnLike")
                {
                    CommentLikeDAO.Instance.UnlikeComment(commentID, loggedInUser.Userid.ToString());
                    btnLike.Text = "Like";
                    lblLikeCount.Text = (newLikeCount-1).ToString();
                }
                else
                {
                    CommentLikeDAO.Instance.likeComment(commentID, loggedInUser.Userid.ToString());
                    lblLikeCount.Text = (newLikeCount+1).ToString();
                    btnLike.Text = "UnLike";

                }


            }
            else
            {
                Response.Redirect("login.aspx");
            }



        }

        protected void btnReply_Click(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                commentTextReply.Value="";
                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

                int itemIndex = item.ItemIndex;
                Comment comment = comments[itemIndex];
                reply_control.Style["display"] = "block";
                replytouser.InnerText ="Reply To: "+comment.User.Username;
                Session["choicerep"] = 1;
                btnSubmitReply.CommandArgument= comment.Commentid.ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btnCancelReply_Click(object sender, EventArgs e)
        {

            reply_control.Style["display"] = "none";
        }

        protected void btnSubmitReply_Click(object sender, EventArgs e)
        {

            string postID = Request.QueryString["PostID"];
            string commentText = commentTextReply.Value;
            string commentIDReply = ((Button)sender).CommandArgument;
            User loggedInUser = (User)Session["User"];
            if ((int)Session["choicerep"] == 0)
            {
                CommentDAO.Instance.InsertCommentPost(Convert.ToInt32(postID), loggedInUser.Userid, commentText);

            }
            else
            {
                CommentDAO.Instance.InsertCommentReply(Convert.ToInt32(postID), loggedInUser.Userid, commentText,commentIDReply);

            }
            //RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            List<Comment> comments = CommentDAO.Instance.GetListCommentByPostID(postID);

            rptComment.DataSource = comments;
            rptComment.DataBind();
            //string a = commentTextReply.Value;
            reply_control.Style["display"] = "none";


            // Sử dụng thông tin của loggedInUser ở đây
        }
        //string commentID = ((Button)sender).CommandArgument;
        //string postID = Request.QueryString["PostID"]; 


    }


}