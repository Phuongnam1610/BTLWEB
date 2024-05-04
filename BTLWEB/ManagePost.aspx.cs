using BTLWEB.DAO;
using BTLWEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLWEB
{
    public partial class ManagePost : System.Web.UI.Page
    {
        User loggedInUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    loggedInUser = (User)Session["user"];
                    List<Post> listPosts = PostDAO.Instance.GetListPostAdmin();
                    rptPost.DataSource=listPosts;
                    rptPost.DataBind();
                }
                // Lấy dữ liệu từ nguồn dữ liệu>
            }




        }


        protected void RptTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Lấy user ID từ item template
                Button btnDuyet = (Button)e.Item.FindControl("btnDuyet");
                Label lbDuyet = (Label)e.Item.FindControl("lbDuyet");
                // Lấy user ID từ session
                User loggedInUser = (User)Session["User"];
                int loggedInUserID = loggedInUser.Userid;
                Post p = (Post)e.Item.DataItem;
              
                if (p.Isapproved==1)
                {

                    lbDuyet.Text = "Đã Duyệt";
                    btnDuyet.Style["visibility"] = "hidden";
                }
                else
                {
                    lbDuyet.Text = "Chưa Duyệt";
                }

            }
        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {
             Button btnDuyet = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnDuyet.NamingContainer;
            int buttonIndex = item.ItemIndex;
            Repeater repeater = (Repeater)item.Parent;
            RepeaterItem targetItem = repeater.Items[buttonIndex];
            Label lblStatus = (Label)targetItem.FindControl("lbDuyet");
            if (lblStatus != null)
            {
                lblStatus.Text = "Đã duyệt";
            }
            string postID = btnDuyet.CommandArgument;
            PostDAO.Instance.UpdatePostApproval(postID);
            btnDuyet.Style["visibility"] = "hidden";

        }
     
        protected void btnXoa_Click(object sender, EventArgs e)
        {
        }
        protected void btnViPham_Click(object sender, EventArgs e)
        {
        }
    }
}