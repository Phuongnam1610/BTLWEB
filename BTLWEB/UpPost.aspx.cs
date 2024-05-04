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
    public partial class UpPost : System.Web.UI.Page
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
                    loggedInUser = (User)Session["user"];

                    List<Category> listCategories = CategoryDAO.Instance.GetListCategory();
                // Lấy dữ liệu từ nguồn dữ liệu và gán vào DropDownList
                if (!IsPostBack) {
                    cateselect.DataSource = listCategories; // Hàm GetCategoriesFromDatabase() trả về danh sách các mục
                    cateselect.DataTextField = "categoryname"; // Tên trường chứa giá trị hiển thị
                    cateselect.DataValueField = "categoryID"; // Tên trường chứa giá trị của mỗi mục
                    cateselect.DataBind();
                    List<Post> listPosts = PostDAO.Instance.GetListPostByUserID(loggedInUser.Userid.ToString());
                    rptPost.DataSource = listPosts;
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
            
                Button btnXoa = (Button)e.Item.FindControl("btnXoa");
                Label lbDuyet = (Label)e.Item.FindControl("lbDuyet");
                // Lấy user ID từ session
                int loggedInUserID = loggedInUser.Userid;
                Post p = (Post)e.Item.DataItem;
                
                if (p.Isapproved==1)
                {

                    lbDuyet.Text = "Đã Duyệt";
                }
                else
                {
                    lbDuyet.Text = "Chưa Duyệt";
                }

            }
        }
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                string tit = title.Value;
                string con = content.Value;
                string idselect = cateselect.SelectedValue;
                string isapproved = "0";
                if (loggedInUser.Isadmin==1)
                {
                    isapproved = "1";
                    
                }
                PostDAO.Instance.InsertNewPost(loggedInUser.Userid.ToString(), tit, con, idselect, isapproved);
                List<Post> listPosts = PostDAO.Instance.GetListPostByUserID(loggedInUser.Userid.ToString());
                rptPost.DataSource=listPosts;
                rptPost.DataBind();
                // Xử lý dữ liệu ở đây

            }
        }
        protected void btnXoa_Click(object sender, EventArgs e)
        {
        }
    
    }
}