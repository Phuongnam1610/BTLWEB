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
    public partial class register : System.Web.UI.Page
    {
        string email;
        string pass;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {

            username=Request.Form["username"];
            email = Request.Form["email"];
            pass = Request.Form["password"];




        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!UserDAO.Instance.CheckEmailExists(email))
            {
                UserDAO.Instance.Register(username,email , pass);

                User user = UserDAO.Instance.getUserData(email, pass);

                if (user!=null)
                {
                    // If the login is valid, retrieve user data and perform session management
                    // For example, retrieve user data from the database


                    // Store user data in session
                    Session["User"] = user;

                    // Redirect to another page
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    message.InnerHtml = "Đã có lỗi xảy ra!";
                }

            }
            else
            {
                message.InnerHtml = "Email đã tồn tại!";
            }


        }



    }
}