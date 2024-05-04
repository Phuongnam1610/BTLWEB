using BTLWEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLWEB
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            // Ẩn hoặc hiển thị phần tử tùy thuộc vào trang hiện tại
            if (currentPage == "login.aspx" || currentPage == "Register.aspx" || currentPage=="UpPost.aspx")
            {
                titlemain.Visible= false;
            }
         
else { titlemain.Visible = true; }
            

            if (Session["User"] != null)
            {
                User loggedInUser = (User)Session["User"];
                IavatarUser.Src= "./Image/"+loggedInUser.Profilepicture;
                panelLogin.Style["display"]  = "none";
                avatarUser.Style["display"] = "block";
                if(loggedInUser.Isadmin ==1)
                {
                    panelAdmin.Style["display"]  = "block";
                }
                // Sử dụng thông tin của loggedInUser ở đây
            }
            else
            {
                panelLogin.Style["display"]  = "block";
                avatarUser.Style["display"] = "none";
            }
        }
       
    }
}