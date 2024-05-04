using BTLWEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLWEB
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] != null)
            {
                User loggedInUser = (User)Session["User"];
                username.InnerText= loggedInUser.Username;
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Xoá tất cả các session
            // Chuyển hướng đến trang đăng nhập
            Response.Redirect("home.aspx");
        }
        protected void fileUpload_UploadedFile(object sender, EventArgs e)
        {
            // Handle the file upload logic here
            // You can access the uploaded file using fileUpload.PostedFile
            // For example, you can save the file to a specific location on the server
        }
    }
}