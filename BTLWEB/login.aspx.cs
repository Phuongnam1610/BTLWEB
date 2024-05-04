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
    public partial class login : System.Web.UI.Page
    {
        string email;
        string pass;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = tbemail.Text;
            pass = tbpassword.Text;
            

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
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
                // If the login is not valid, display an error message
                // For example, show an error message on the login page
                wrongp.Style["visibility"] = "visible";
            }
        }

     
 
    }
}  